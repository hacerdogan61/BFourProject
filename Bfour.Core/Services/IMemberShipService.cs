using System;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IMemberShipService:IServices<MemberShip>
	{

		public Task<Result<List<MemberShipDTO>>> GetMemberShipList();


	}
}

