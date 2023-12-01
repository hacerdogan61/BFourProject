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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bfour.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : CustomBaseController
    {
        private readonly IServices<Product> _services;
        private readonly IMapper _mapper;
        public ProductController(IServices<Product> services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet("api/Product/GetProducts")]
        public  IActionResult GetProducts()
        {
            var products =  _services.GetAll();
            return CreateActionResult(products);
        }

        // GET api/values/5
        [HttpPost("api/Product/GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _services.GetByIdAsync(id);
            return CreateActionResult(product);
        }

        [HttpPost("api/Product/InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]ProductDTO value)
        {
            var product = await _services.AddAsync(_mapper.Map<Product>(value));
            return CreateActionResult(product);
        }

        [HttpPost("api/Product/UpdateAsync")]
        public async Task<IActionResult> Put([FromBody]ProductDTO value)
        {
            var memberAppointment = await _services.AddAsync(_mapper.Map<Product>(value));
            return CreateActionResult(memberAppointment);
        }
    }
}

