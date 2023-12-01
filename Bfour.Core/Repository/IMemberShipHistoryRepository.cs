using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IMemberShipHistoryRepository:IGenericRepository<MembershipHistory>
	{
        public Task<List<MembershipHistory>> GetMemberShipHistoryAsync();

    }
}

