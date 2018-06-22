using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.UnitOfWork;
using Application.Domain;
using Application.Web.Areas.Admin.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAttributeController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProductAttributeController(IUnitOfWork uow, IMapper mapper, ILogger<CategoryController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductAttribute> productAttributes = await _uow.ProductAttributes.GetAllAsync();
            var productAttributeViewModel = _mapper.Map<IEnumerable<ProductAttributeViewModel>>(productAttributes);
            return View(productAttributeViewModel);
        }
    }
}