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
    public class AttributeValueController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AttributeValueController(IUnitOfWork uow, IMapper mapper, ILogger<AttributeValueController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index(long? id)
        {
            IEnumerable<AttributeValueViewModel> attributeValueViewModels = null;

            if (id.HasValue)
            {
                Expression<Func<AttributeValue, bool>> isExistAttributeValues = (p) => p.AttributeId == id;
                var attributeValues = await _uow.AttributeValues.FindAsync(isExistAttributeValues);
                if (attributeValues != null)
                {
                    attributeValueViewModels = _mapper.Map<IEnumerable<AttributeValueViewModel>>(attributeValues);
                }                
            }
            ViewData["AttributeId"] = id;
            return View(attributeValueViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditAttributeValue(long? id, long attributeId)
        {

            AttributeValueViewModel attributeValueViewModel = new AttributeValueViewModel
            {
                AttributeId = attributeId
            };

            if (id.HasValue)
            {
                var attributeValue = await _uow.AttributeValues.GetAsync(id.Value);
                if (attributeValue == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, attributeValueViewModel);
                    return NotFound();
                }

                attributeValueViewModel = _mapper.Map<AttributeValueViewModel>(attributeValue);
            }

            return PartialView("~/Areas/Admin/Views/AttributeValue/_AddEditAttributeValue.cshtml", attributeValueViewModel);
        }

        [HttpPost, ActionName("AddEditAttributeValue")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditAttributeValue(long? id, AttributeValueViewModel attributeValueViewModel)
        {
            try
            {
                if (attributeValueViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, attributeValueViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var attributeValue = _mapper.Map<AttributeValue>(attributeValueViewModel);
                        await _uow.AttributeValues.AddAsync(attributeValue);
                        _logger.LogInformation(LogMessageConstant.Added, attributeValue.Name);
                    }
                    else
                    {
                        var attributeValue = _mapper.Map<AttributeValue>(attributeValueViewModel);
                        await _uow.AttributeValues.UpdateAsync(id.Value, attributeValue);
                        _logger.LogInformation(LogMessageConstant.Updated, attributeValue.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.AttributeValues.GetAsync(id.Value);
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

            return RedirectToAction(nameof(Index),new { id= attributeValueViewModel.AttributeId });
        }
    }
    
}