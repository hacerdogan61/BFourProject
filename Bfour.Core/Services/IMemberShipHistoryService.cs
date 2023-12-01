using System;
using Bfour.Core.Entities;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IMemberShipHistoryService:IServices<MembershipHistory>
	{
         Task<Result<List<MembershipHistory>>> GetMemberShipHistoryAsync();
         Result<IQueryable<MembershipHistory>> GetMemberShipHistoryByMemberIdAsync(int memberId);
        Result<IQueryable<MembershipHistory>> GetMemberShipHistoryByProductIdAsync(int productId);
    }
}

