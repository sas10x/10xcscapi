using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Session;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class OrdersController : BaseController
    {
        [HttpGet]
        // [Authorize(Policy = "IsActivityHost")]
        [Authorize]
        public async Task<ActionResult<List<OrderDto>>> List()
        {
            return await Mediator.Send(new ListOrder.Query());
        }
        [HttpPost]
        public async Task<ActionResult<Order>> Create (AddOrder.Command command)
        {
            var order = await Mediator.Send(command);
            return Ok(order);
        }   
        [Authorize]
        [HttpPut("finish")]
        public async Task<ActionResult<Unit>> Finish (FinishOrder.Command command)
        {
            return await Mediator.Send(command);
        }   
    }
}