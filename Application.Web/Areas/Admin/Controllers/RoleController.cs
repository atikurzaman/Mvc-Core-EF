using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.UnitOfWork;
using Application.Domain.Membership;
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
    public class RoleController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RoleController(IUnitOfWork uow, IMapper mapper, ILogger<RoleController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Role> roles = await _uow.Roles.GetAllAsync();
            var roleViewModel = _mapper.Map<IEnumerable<RoleViewModel>>(roles);
            return View(roleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditRole(long? id)
        {
            RoleViewModel roleViewModel = new RoleViewModel();
            if (id.HasValue)
            {
                var role = await _uow.Roles.GetAsync(id.Value);
                if (role == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, typeof(Role), id);
                    return NotFound();
                }
                
                roleViewModel = _mapper.Map<RoleViewModel>(role);                 
                roleViewModel.IsActiveSelectList = new SelectList(GetIsActiveSelectList(), "Value", "Text", roleViewModel.IsActive);
            }
            else
            {                
                roleViewModel.IsActiveSelectList = new SelectList(GetIsActiveSelectList(), "Value", "Text", "True");
            }

            return PartialView("~/Areas/Admin/Views/Role/_AddEditRole.cshtml", roleViewModel);
        }

        [HttpPost, ActionName("AddEditRole")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditRole(long? id, RoleViewModel roleViewModel)
        {
            try
            {
                if (roleViewModel == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var role = _mapper.Map<Role>(roleViewModel);
                        await _uow.Roles.AddAsync(role);
                        _logger.LogInformation(LogMessageConstant.Added, typeof(Role), role.Name);
                        TempData["Message"] = ApplicationMessage.Save;
                    }
                    else
                    {
                        var role = _mapper.Map<Role>(roleViewModel);
                        await _uow.Roles.UpdateAsync(id.Value, role);
                        _logger.LogInformation(LogMessageConstant.Updated, typeof(Role), role.Name);
                        TempData["Message"] = ApplicationMessage.Update;
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.Roles.GetAsync(id.Value);
                if (isExist == null)
                {
                    _logger.LogWarning(LogMessageConstant.IdNotFound, typeof(Role), id);
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
        public async Task<IActionResult> DeleteRole(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _uow.Roles.GetAsync(id.Value);
            if (role == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, typeof(Role), id);
                return NotFound();
            }

            var roleViewModel = _mapper.Map<RoleViewModel>(role);
            string roleName = roleViewModel.Name;
            return PartialView("~/Areas/Admin/Views/Role/_DeleteRole.cshtml", model: roleName);
        }

        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(long id, IFormCollection form)
        {
            try
            {
                var role = await _uow.Roles.GetAsync(id);
                await _uow.Roles.DeleteAsync(role.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, role.Id);
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