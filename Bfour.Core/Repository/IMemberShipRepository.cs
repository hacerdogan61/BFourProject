using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IMemberShipRepository: IGenericRepository<MemberShip>
	{

		public Task<List<MemberShip>> GetMemberShipAsync();
	}
}

