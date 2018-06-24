using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Data.UnitOfWork;
using Application.Domain;
using Application.Web.Areas.Admin.Models;
using Application.Web.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAttributeItemController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProductAttributeItemController(IUnitOfWork uow, IMapper mapper, ILogger<ProductAttributeItemController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index(long? id)
        {
            IEnumerable<ProductAttributeItemViewModel> productAttributeItemViewModels = null;

            if (id.HasValue)
            {
                Expression<Func<ProductAttributeItem, bool>> isExistProductAttributeItems = (p) => p.ProductAttributeId == id;
                var productAttributeItems = await _uow.ProductAttributeItems.FindAsync(isExistProductAttributeItems);
                if (productAttributeItems != null)
                {
                    productAttributeItemViewModels = _mapper.Map<IEnumerable<ProductAttributeItemViewModel>>(productAttributeItems);
                }                
            }
            ViewData["ProductAttributeId"] = id;
            return View(productAttributeItemViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditProductAttributeItem(long? id, long productAttributeId)
        {

            ProductAttributeItemViewModel productAttributeItemViewModel = new ProductAttributeItemViewModel();
            productAttributeItemViewModel.ProductAttributeId = productAttributeId;
            
            if (id.HasValue)
            {
                var productAttributeItem = await _uow.ProductAttributeItems.GetAsync(id.Value);
                if (productAttributeItem == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, productAttributeItemViewModel);
                    return NotFound();
                }

                productAttributeItemViewModel = _mapper.Map<ProductAttributeItemViewModel>(productAttributeItem);
            }

            return PartialView("~/Areas/Admin/Views/ProductAttributeItem/_AddEditProductAttributeItem.cshtml", productAttributeItemViewModel);
        }

        [HttpPost, ActionName("AddEditProductAttributeItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditProductAttributeItem(long? id, ProductAttributeItemViewModel productAttributeItemViewModel)
        {
            try
            {
                if (productAttributeItemViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, productAttributeItemViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var productAttributeItem = _mapper.Map<ProductAttributeItem>(productAttributeItemViewModel);
                        await _uow.ProductAttributeItems.AddAsync(productAttributeItem);
                        _logger.LogInformation(LogMessageConstant.Added, productAttributeItem.Name);
                    }
                    else
                    {
                        var productAttributeItem = _mapper.Map<ProductAttributeItem>(productAttributeItemViewModel);
                        await _uow.ProductAttributeItems.UpdateAsync(id.Value, productAttributeItem);
                        _logger.LogInformation(LogMessageConstant.Updated, productAttributeItem.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.ProductAttributeItems.GetAsync(id.Value);
                if (isExist == null)
                {
                    _logger.LogWarning(LogMessageConstant.IdNotFound, id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ce.Message, id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }           

            return RedirectToAction(nameof(Index),new { id= productAttributeItemViewModel.ProductAttributeId });
        }
    }
    
}