using System;
using AutoMapper;
using AutoMapper.Execution;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;

namespace Bfour.Service.Service
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository,  IGenericRepository<Order> repository, IUnitOfWorks unitOfWorks) : base(repository, unitOfWorks)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<Order>> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return Result<Order>.Success(200, order, true);

        }

        public async Task<Result<Order>> GetOrderByMemberId(int memberId)
        {
            var order = await _orderRepository.GetByIdAsync(memberId);
            return Result<Order>.Success(200, order, true);
        }


        public async Task<Result<IEnumerable<Order>>> GetOrderList()
        {
            var order = await _orderRepository.GetListOrder();
            return Result<IEnumerable<Order>>.Success(200, order, true);
        }
    }
}

