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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BfourProject.UI.Controllers
{
    public class OrderController : BaseController
    {

        private readonly IOrderDetailService _servicesOrderDetail;
        private readonly IOrderService _servicesOrder;
        private readonly IServices<Pos> _posServices;
        private readonly IServices<PaymentType> _paymentTypeServices;
        private readonly IMapper _mapper;
        // GET: /<controller>/


        public OrderController(IOrderService servicesOrder, IOrderDetailService servicesOrderDetail, IMapper mapper, IServices<Pos> posServices, IServices<PaymentType> paymentTypeServices)
        {
            _servicesOrder = servicesOrder;
            _servicesOrderDetail = servicesOrderDetail;
            _posServices = posServices;
            _paymentTypeServices = paymentTypeServices;
            _posServices = posServices;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _servicesOrder.GetOrderList();
            return CreateActionResult(order);
        }

        [HttpGet]
        public  IActionResult GetPaymentTypeList()
        {
            var paymentTypeList =  _paymentTypeServices.GetAll();
            return CreateActionResult(paymentTypeList);
        }
        [HttpGet]
        public IActionResult GetPOSList()
        {
            var posList = _posServices.GetAll();
            return CreateActionResult(posList);
        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]OrderDTO order)
        {
            var insertOrder = await _servicesOrder.AddAsync(_mapper.Map<Order>(order));
            return CreateActionResult(insertOrder);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAndUpdate([FromBody] Order value)
        {
            var update = await _servicesOrder.UpdateAsync(value);
            return CreateActionResult(update);
        }

    }
}

