using System;
using Bfour.Core.Entities;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IOrderDetailService : IServices<OrderDetail>
    {
        public Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailListAsync();

        public Task<Result<OrderDetail>> GetOrderDetailByIdAsync(int id);

        public Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailByMemberShipIdAsync(int memberShipId);

        public Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailByOrderIdAsync(int orderId);

        public Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailByProductIdAsync(int productId);
    }
}

