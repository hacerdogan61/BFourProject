using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.Services;
using Bfour.Service.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BfourProject.UI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _services;
        private readonly IMapper _mapper;
        private readonly IServices<ProductDiscount> _productDiscountService;
        public ProductController(IProductService services, IMapper mapper, IServices<ProductDiscount> productDiscountService)
        {
            _services = services;
            _productDiscountService = productDiscountService;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _services.GetProductsWithRelationsAsync();
            return CreateActionResult(products);
        }
        [HttpGet]
        public IActionResult GetAllProductDiscount()
        {
            var productDiscounts =  _productDiscountService.GetAll();
            return CreateActionResult(productDiscounts);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductDTO value)
        {
            var product = await _services.AddAsync(_mapper.Map<Product>(value));
            return CreateActionResult(product);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAndUpdate([FromBody]Product value)
        {
            var update = await _services.UpdateAsync(value);
            return CreateActionResult(update);
        }
    }
}

