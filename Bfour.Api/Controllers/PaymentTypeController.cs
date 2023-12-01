using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bfour.Core.Entities;
using Bfour.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bfour.Api.Controllers
{
    [Route("api/[controller]")]
    public class PaymentTypeController : CustomBaseController
    {

        private readonly IServices<PaymentType> _services;

        public PaymentTypeController(IServices<PaymentType> services)
        {
            _services = services;

        }
        // GET: api/values
        [HttpGet("api/PaymentType/getAll")]
        public IActionResult GetAll()
        {
            return CreateActionResult(_services.GetAll());
        }

        // GET api/values/5
        [HttpGet("api/PaymentType/getById")]
        public async Task<IActionResult> GetById(int id)
        {
             return CreateActionResult(await _services.GetByIdAsync(id));
        }

        // POST api/values
        [HttpPost("api/PaymentType/insert")]
        public async Task<IActionResult> Insert([FromBody]PaymentType value)
        {
            return CreateActionResult(await _services.AddAsync(value));
        }

        // PUT api/values/5
        [HttpPost("api/PaymentType/update")]
        public async Task<IActionResult> Update([FromBody] PaymentType value)
        {
            return CreateActionResult(await _services.UpdateAsync(value));

        }
    }
}

