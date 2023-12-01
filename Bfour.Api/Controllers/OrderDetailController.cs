using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bfour.Core.DTO;
using Bfour.Core.Entities;
using Bfour.Core.Services;
using Bfour.Service.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bfour.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetailController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IServices<OrderDetail> _servicesOrderDetail;
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IMapper mapper, IServices<OrderDetail> servicesOrderDetail, IOrderDetailService orderDetailService)
        {
            _mapper = mapper;
            _servicesOrderDetail = servicesOrderDetail;
            _orderDetailService = orderDetailService;
        }

        // GET: api/values
        [HttpGet("api/OrderDetail/getAllJustOrderDetail")]
        public IActionResult GetAllJustOrderDetail()
        {
            var orderDetails = _servicesOrderDetail.GetAll();
            return CreateActionResult(orderDetails);
        }
        [HttpGet("api/OrderDetail/getAllOrderDetailAsync")]
        public async Task<IActionResult> GetAllOrderDetailAsync()
        {
            var orderDetails = await _orderDetailService.GetOrderDetailListAsync();
            return CreateActionResult(orderDetails);
        }

        [HttpGet("api/OrderDetail/getOrderDetailById")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailByIdAsync(id);
            return CreateActionResult(orderDetails);
        }

        // GET api/values/5
        [HttpGet("api/OrderDetail/getOrderDetailByOrderId")]
        public async Task<IActionResult> GetOrderDetailByOrderId(int orderId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailByOrderIdAsync(orderId);
            return CreateActionResult(orderDetails);
        }
        [HttpGet("api/OrderDetail/getOrderDetailByProductId")]
        public async Task<IActionResult> GetOrderDetailByProductId(int productId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailByProductIdAsync(productId);
            return CreateActionResult(orderDetails);
        }
        [HttpGet("api/OrderDetail/getOrderDetailByMemberShipId")]
        public async Task<IActionResult> GetOrderDetailByMemberShipId(int memberShipId)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailByMemberShipIdAsync(memberShipId);
            return CreateActionResult(orderDetails);
        }
        // POST api/values
        [HttpPost("api/OrderDetail/insert")]
        public async Task<IActionResult> Insert([FromBody]OrderDetailDTO value)
        {

            var insertOrderDetail = await _servicesOrderDetail.AddAsync(_mapper.Map<OrderDetail>(value));
            return CreateActionResult(insertOrderDetail);
        }

        // PUT api/values/5
        [HttpPost("api/OrderDetail/update")]
        public async Task<IActionResult> Update([FromBody]OrderDetailDTO value)
        {
            var updateOrderDetail = await _servicesOrderDetail.UpdateAsync(_mapper.Map<OrderDetail>(value));
            return CreateActionResult(updateOrderDetail);
        }
    }
}

