using System;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IOrderService:IServices<Order>
	{
        public Task<Result<IEnumerable<Order>>> GetOrderList();

        public Task<Result<Order>> GetOrderById(int id);

        public Task<Result<Order>> GetOrderByMemberId(int memberId);

    }
}

