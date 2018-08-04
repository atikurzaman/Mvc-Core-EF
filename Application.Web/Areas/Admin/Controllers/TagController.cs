using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.UnitOfWork;
using Application.Domain;
using Application.Utility;
using Application.Web.Areas.Admin.Models;
using Application.Web.Common;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TagController(IUnitOfWork uow, IMapper mapper, ILogger<TagController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Tag> tags = await _uow.Tags.GetAllAsync();
            var tagViewModel = _mapper.Map<IEnumerable<TagViewModel>>(tags);
            return View(tagViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditTag(long? id)
        {
            TagViewModel tagViewModel = new TagViewModel();
            if (id.HasValue)
            {
                var tag = await _uow.Tags.GetAsync(id.Value);
                if (tag == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, typeof(Tag), id);
                    return NotFound();
                }
                
                tagViewModel = _mapper.Map<TagViewModel>(tag);                 
                tagViewModel.IsActiveSelectList = new SelectList(GetIsActiveSelectList(), "Value", "Text", tagViewModel.IsActive);
            }
            else
            {                
                tagViewModel.IsActiveSelectList = new SelectList(GetIsActiveSelectList(), "Value", "Text", "True");
            }

            return PartialView("~/Areas/Admin/Views/Tag/_AddEditTag.cshtml", tagViewModel);
        }

        [HttpPost, ActionName("AddEditTag")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditTag(long? id, TagViewModel tagViewModel)
        {
            try
            {
                if (tagViewModel == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var tag = _mapper.Map<Tag>(tagViewModel);
                        await _uow.Tags.AddAsync(tag);
                        _logger.LogInformation(LogMessageConstant.Added, typeof(Tag), tag.Name);
                        TempData["Message"] = ApplicationMessage.Save;
                    }
                    else
                    {
                        var tag = _mapper.Map<Tag>(tagViewModel);
                        await _uow.Tags.UpdateAsync(id.Value, tag);
                        _logger.LogInformation(LogMessageConstant.Updated, typeof(Tag), tag.Name);
                        TempData["Message"] = ApplicationMessage.Update;
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.Tags.GetAsync(id.Value);
                if (isExist == null)
                {
                    _logger.LogWarning(LogMessageConstant.IdNotFound, typeof(Tag), id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ce.Message, id);
                    TempData["Message"] = ApplicationMessage.FailedToUpdateConcurrency;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                TempData["Message"] = ApplicationMessage.Fail;
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteTag(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _uow.Tags.GetAsync(id.Value);
            if (tag == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, typeof(Tag), id);
                return NotFound();
            }

            var tagViewModel = _mapper.Map<TagViewModel>(tag);
            string tagName = tagViewModel.Name;
            return PartialView("~/Areas/Admin/Views/Tag/_DeleteTag.cshtml", model: tagName);
        }

        [HttpPost, ActionName("DeleteTag")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTag(long id, IFormCollection form)
        {
            try
            {
                var tag = await _uow.Categories.GetAsync(id);
                await _uow.Tags.DeleteAsync(tag.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, tag.Id);
                TempData["Message"] = ApplicationMessage.Delete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                TempData["Message"] = ApplicationMessage.FailToDelete;
            }

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetIsActiveSelectList()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            var items = new[]{
                 new SelectListItem{ Value=true.ToString(),Text="Active"},
                 new SelectListItem{ Value=false.ToString(),Text="Inactive"}
             };

            selectListItems = items.ToList();
            return selectListItems;
        }
    }
}