using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.UnitOfWork;
using Application.Domain;
using Application.Web.Areas.Admin.Models;
using Application.Web.Common;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttributeController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AttributeController(IUnitOfWork uow, IMapper mapper, ILogger<AttributeController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Domain.Attribute> attributes = await _uow.Attributes.GetAllAsync();
            var attributeViewModel = _mapper.Map<IEnumerable<AttributeViewModel>>(attributes);
            return View(attributeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditAttribute(long? id)
        {
            AttributeViewModel attributeViewModel = new AttributeViewModel();
            if (id.HasValue)
            {
                var attribute = await _uow.Attributes.GetAsync(id.Value);
                if (attribute == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, attributeViewModel);
                    return NotFound();
                }

                attributeViewModel = _mapper.Map<AttributeViewModel>(attribute);
            }

            return PartialView("~/Areas/Admin/Views/Attribute/_AddEditAttribute.cshtml", attributeViewModel);
        }

        [HttpPost, ActionName("AddEditAttribute")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditAttribute(long? id, AttributeViewModel attributeViewModel)
        {
            try
            {
                if (attributeViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, attributeViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var attribute = _mapper.Map<Domain.Attribute>(attributeViewModel);
                        await _uow.Attributes.AddAsync(attribute);
                        _logger.LogInformation(LogMessageConstant.Added, attribute.Name);
                    }
                    else
                    {
                        var attribute = _mapper.Map<Domain.Attribute>(attributeViewModel);
                        await _uow.Attributes.UpdateAsync(id.Value, attribute);
                        _logger.LogInformation(LogMessageConstant.Updated, attribute.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.Attributes.GetAsync(id.Value);
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

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteAttribute(long? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LogMessageConstant.IdIsNull);
                return NotFound();
            }

            var attribute = await _uow.Attributes.GetAsync(id.Value);
            if (attribute == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, id);
                return NotFound();
            }

            var attributeViewModel = _mapper.Map<AttributeViewModel>(attribute);
            string attributeName = attributeViewModel.Name;
            return PartialView("~/Areas/Admin/Views/Attribute/_DeleteAttribute.cshtml", model: attributeName);
        }

        [HttpPost, ActionName("DeleteAttribute")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAttribute(long id, IFormCollection form)
        {
            try
            {
                var attribute = await _uow.Attributes.GetAsync(id);
                await _uow.Attributes.DeleteAsync(attribute.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, attribute.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}