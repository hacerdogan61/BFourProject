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
    public class OrderController : CustomBaseController
    {

        private readonly IServices<OrderDetail> _servicesOrderDetail;
        private readonly IOrderService _servicesOrder;
        private readonly IMapper _mapper;

        public OrderController(IOrderService servicesOrder, IServices<OrderDetail> servicesOrderDetail,IMapper mapper)
        {
            _servicesOrder = servicesOrder;
            _servicesOrderDetail = servicesOrderDetail;
            _mapper = mapper;
        }


        // GET: api/values

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _servicesOrder.GetOrderList();
            return CreateActionResult(order);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _servicesOrder.GetOrderById(id);
            return CreateActionResult(order);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderDTO order)
        {
            var insertOrder = await _servicesOrder.AddAsync(_mapper.Map<Order>(order));
            order.OrderDetails.ForEach(x => { x.OrderId = insertOrder.Data.Id; });
            var insertOrderDetail = await _servicesOrderDetail.AddRangeAsync(_mapper.Map<List<OrderDetail>>(order.OrderDetails));
            return CreateActionResult(insertOrderDetail);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]OrderDTO order)
        {
            var mappOrder = _mapper.Map<Order>(order);
            mappOrder.Id = id;
            mappOrder.UpdateDate = DateTime.Now;
            return CreateActionResult(await _servicesOrder.UpdateAsync(mappOrder));
        }

       
    }
}

