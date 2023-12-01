using System;
using System.Collections.Generic;
using AutoMapper;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;

namespace Bfour.Service.Service
{
    public class MemberShipService : Service<MemberShip>, IMemberShipService
    {
        public readonly IMemberShipRepository _memberShipRepository;
        private readonly IMapper _mapper;

        public MemberShipService(IGenericRepository<MemberShip> repository, IUnitOfWorks unitOfWorks,
            IMemberShipRepository memberShipRepository, IMapper mapper) : base(repository, unitOfWorks)
        {
            _memberShipRepository = memberShipRepository;
            _mapper = mapper;
        }


        public async Task<Result<List<MemberShipDTO>>> GetMemberShipList()
        {
            var memberShip = await _memberShipRepository.GetMemberShipAsync();
            var memberShipDTO = _mapper.Map<List<MemberShipDTO>>(memberShip);
            return Result<List<MemberShipDTO>>.Success(200,memberShipDTO,true);

        }
    }
}

