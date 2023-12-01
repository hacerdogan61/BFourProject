using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IOrderRepository :IGenericRepository<Order>
	{
		public Task<IEnumerable<Order>> GetListOrder();

		public Task<Order> GetOrderById(int id);

        public Task<Order> GetOrderByMemberId(int memberId);

    }
}

