using AutoMapper;
using AutoMapper.Execution;
using Bfour.Core.Entities;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Member = Bfour.Core.Entities.Member;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bfour.Api.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IServices<Member> _service;

        

        public MemberController(IMapper mapper, IServices<Member> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var members =   _service.GetAll();
            return CreateActionResult( members);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var member = await _service.GetByIdAsync(id);
            return CreateActionResult(member);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]Member value)
        {
           var newMember= await _service.AddAsync(value);
            return CreateActionResult(newMember);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Member value)
        {
            var update=await _service.UpdateAsync(value);
            return CreateActionResult(update);
        }

    }
}

