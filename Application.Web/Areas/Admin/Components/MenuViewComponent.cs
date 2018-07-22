using Application.Data.UnitOfWork;
using Application.Domain;
using Application.Web.Areas.Admin.Controllers;
using Application.Web.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public MenuViewComponent(IUnitOfWork uow, IMapper mapper, ILogger<MenuController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Menu> allMenu = await _uow.Menus.GetAllAsync();

            List<Menu> menus = allMenu.Where(e => e.ParentId == null) /* grab only the root parent nodes */
            .Select(e => new Menu
            {
                Id = e.Id,
                Name = e.Name,
                ControllerName=e.ControllerName,
                ActionName =e.ActionName,
                CssClass =e.CssClass,
                IsActive =e.IsActive,
                ParentId = e.ParentId,
                Children = GetChildren(allMenu.ToList(), e.Id) /* Recursively grab the children */
            }).ToList();

            var menuViewModels = _mapper.Map<IEnumerable<MenuViewModel>>(menus);

            return View("Menu", menuViewModels);

        }
        private static List<Menu> GetChildren(List<Menu> menus, Int64 parentId)
        {
            return menus
                .Where(x => x.ParentId == parentId)
                .Select(e => new Menu
                {
                    Id = e.Id,
                    Name = e.Name,
                    ControllerName = e.ControllerName,
                    ActionName = e.ActionName,
                    CssClass = e.CssClass,
                    IsActive = e.IsActive,
                    ParentId = e.ParentId,
                    Children = GetChildren(menus, e.Id)
                }).ToList();
        }
    }
}
