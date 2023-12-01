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
    public class MemberShipHistoryController : CustomBaseController
    {
        private readonly IMemberShipHistoryService _memberShipHistoryService;
        private readonly IMapper _mapper;
        public MemberShipHistoryController(IMemberShipHistoryService memberShipHistoryService, IMapper mapper)
        {
            _memberShipHistoryService = memberShipHistoryService;
            _mapper = mapper;
        }


        // GET: api/values
        [HttpGet("api/MemberShipHistory/GetAllMemberShipHistoryAsync")]
        public async Task<IActionResult> GetAllMemberShipHistoryAsync()
        {
            var memberShipHistories = await _memberShipHistoryService.GetMemberShipHistoryAsync();
            return CreateActionResult(memberShipHistories);
        }

        // GET api/values/5
        [HttpPost("api/MemberShipHistory/GetMemberShipHistoryByMemberIdAsync")]
        public IActionResult GetMemberShipHistoryByMemberIdAsync(int memberId)
        {
            var memberShipHistories = _memberShipHistoryService.GetMemberShipHistoryByMemberIdAsync(memberId);
            return CreateActionResult(memberShipHistories);
        }

        [HttpPost("api/MemberShipHistory/GetMemberShipHistoryByMemberIdAsync")]
        public IActionResult GetMemberShipHistoryByProductIdAsync(int productId)
        {
            var memberShipHistories = _memberShipHistoryService.GetMemberShipHistoryByProductIdAsync(productId);
            return CreateActionResult(memberShipHistories);
        }

        [HttpPost("api/MemberShipHistory/GetMemberShipHistoryBIdAsync")]
        public async Task<IActionResult> GetMemberShipHistoryBIdAsync(int id)
        {
            var memberShipHistories = await _memberShipHistoryService.GetByIdAsync(id);
            return CreateActionResult(memberShipHistories);
        }

        // POST api/values
        [HttpPost("api/MemberShipHistory/InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]MemberAppointmentDTO value)
        {
            var memberShipHistory = await _memberShipHistoryService.AddAsync(_mapper.Map<MembershipHistory>(value));
            return CreateActionResult(memberShipHistory);
        }

        [HttpPost("api/MemberShipHistory/UpdateAsync")]
        public async Task<IActionResult> Put([FromBody] MemberAppointmentDTO value)
        {
            var memberShipHistory = await _memberShipHistoryService.UpdateAsync(_mapper.Map<MembershipHistory>(value));
            return CreateActionResult(memberShipHistory);
        }
    }
}

