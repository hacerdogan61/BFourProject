using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bfour.Api.Controllers
{
    [Route("api/[controller]")]
    public class MemberAppointmentController : CustomBaseController
    {
        private readonly IMemberAppointmentService _memberAppointmentService;
        private readonly IMapper _mapper;

        public MemberAppointmentController(IMemberAppointmentService memberAppointmentService, IMapper mapper)
        {
            _memberAppointmentService = memberAppointmentService;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet("api/MemberAppointment/getAllMemberAppointmentAsync")]
        public async Task<IActionResult> GetAllMemberAppointmentAsync()
        {
            var memberAppointments = await _memberAppointmentService.GetMemberAppointmentAllAsync();
            return CreateActionResult(memberAppointments);
        }

        // GET api/values/5
        [HttpGet("api/MemberAppointment/getMemberAppointmentByIdAsync")]
        public IActionResult GetMemberAppointmentByIdAsync(int id)
        {
            var memberAppointment =  _memberAppointmentService.GetMemberAppointmentById(id);
            return CreateActionResult(memberAppointment);
        }

        // POST api/values
        [HttpPost("api/MemberAppointment/InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]MemberAppointmentDTO value)
        {
            var memberAppointment = await _memberAppointmentService.AddAsync(_mapper.Map<MemberAppointment>(value));
            return CreateActionResult(memberAppointment);
        }

        // PUT api/values/5
        [HttpPost("api/MemberAppointment/UpdateAsync")]
        public async Task<IActionResult> Put([FromBody] MemberAppointmentDTO value)
        {
            var memberAppointment = await _memberAppointmentService.UpdateAsync(_mapper.Map<MemberAppointment>(value));
            return CreateActionResult(memberAppointment);
        }

    }
}

