using System;
using System.Collections.Generic;
using AutoMapper.Execution;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;

namespace Bfour.Service.Service
{
	public class MemberShipHistoryService : Service<MembershipHistory>, IMemberShipHistoryService
    {
        private readonly IMemberShipHistoryRepository _memberShipHistoryRepository;

        public MemberShipHistoryService(IMemberShipHistoryRepository memberShipHistoryRepository,IGenericRepository<MembershipHistory> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
        {
            _memberShipHistoryRepository = memberShipHistoryRepository;
        }

        public async Task<Result<List<MembershipHistory>>> GetMemberShipHistoryAsync()
        {
            return Result<List<MembershipHistory>>.Success(200, await _memberShipHistoryRepository.GetMemberShipHistoryAsync(), true);
        }
        
        public Result<IQueryable<MembershipHistory>> GetMemberShipHistoryByMemberIdAsync(int memberId)
        {
            IQueryable<MembershipHistory> list = _memberShipHistoryRepository.Where(x=>x.MemberId==memberId);
            return Result<IQueryable<MembershipHistory>>.Success(200,list,true);
        }

        public Result<IQueryable<MembershipHistory>> GetMemberShipHistoryByProductIdAsync(int productId)
        {
            IQueryable<MembershipHistory> list = _memberShipHistoryRepository.Where(x => x.MemberId == productId);
            return Result<IQueryable<MembershipHistory>>.Success(200, list, true);
        }
    }
}

