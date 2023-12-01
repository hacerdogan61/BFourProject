using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        public Task<IEnumerable<OrderDetail>> GetListOrderDetailAsync();

        public Task<OrderDetail> GetOrderDetailByIdAsync(int id);

        public Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);

        public Task<IEnumerable<OrderDetail>> GetOrderDetailsByMemberShipIdAsync(int memberShipId);

        public Task<IEnumerable<OrderDetail>> GetOrderDetailsByProductIdAsync(int productId);
    }
}

