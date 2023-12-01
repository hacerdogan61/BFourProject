using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BfourProject.UI.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IServices<Member> _service;

        public MemberController(IMapper mapper, IServices<Member> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var members = _service.GetAll();
            return CreateActionResult(members);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MemberDTO value)
        {
            var mappValue = _mapper.Map<Member>(value);
            mappValue.BirthDate = DateTime.Now.AddYears(-20);
            var newMember = await _service.AddAsync(mappValue);
            return CreateActionResult(newMember);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAndUpdate([FromBody] Member value)
        {
            var update = await _service.UpdateAsync(value);
            return CreateActionResult(update);
        }

    }
}