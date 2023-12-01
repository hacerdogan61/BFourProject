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
    public class MemberShipController : CustomBaseController
    {
        private readonly IMemberShipService _memberShipServices;
        private readonly IMapper _mapper;

        public MemberShipController(IMapper mapper,IMemberShipService memberShipServices)
        {
            _memberShipServices = memberShipServices;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var members = _memberShipServices.GetAll();
            return CreateActionResult(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberShipServices.GetByIdAsync(id);
            return CreateActionResult(member);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]MemberShipDTO value)
        {
            var newMemberShip = await _memberShipServices.AddAsync(_mapper.Map<MemberShip>(value));
            return CreateActionResult(newMemberShip);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MemberShip value)
        {
            value.Id = id;
            var update = await _memberShipServices.UpdateAsync(value);
            return CreateActionResult(update);
        }

      
    }
}

