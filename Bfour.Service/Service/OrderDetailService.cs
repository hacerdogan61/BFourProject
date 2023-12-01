using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;
using Bfour.Repository.Repository;

namespace Bfour.Service.Service
{
    public class OrderDetailService :Service<OrderDetail>, IOrderDetailService
	{
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository,IGenericRepository<OrderDetail> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Result<OrderDetail>> GetOrderDetailByIdAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            return Result<OrderDetail>.Success(200, orderDetail, true);
        }

        public async Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailByMemberShipIdAsync(int memberShipId)
        {
            var orderDetailByMemberId = await _orderDetailRepository.GetOrderDetailsByMemberShipIdAsync(memberShipId);
            return Result<IEnumerable<OrderDetail>>.Success(200, orderDetailByMemberId, true);
        }

        public async Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailByOrderIdAsync(int orderId)
        {
            var orderDetailByOrderId = await _orderDetailRepository.GetOrderDetailsByOrderIdAsync(orderId);
            return Result<IEnumerable<OrderDetail>>.Success(200, orderDetailByOrderId, true);
        }

        public async Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailByProductIdAsync(int productId)
        {
            var orderDetailByProductId = await _orderDetailRepository.GetOrderDetailsByProductIdAsync(productId);
            return Result<IEnumerable<OrderDetail>>.Success(200, orderDetailByProductId, true);
        }

        public async  Task<Result<IEnumerable<OrderDetail>>> GetOrderDetailListAsync()
        {
            var orderDetails = await _orderDetailRepository.GetListOrderDetailAsync();
            return Result<IEnumerable<OrderDetail>>.Success(200, orderDetails, true);
        }
    }
}

