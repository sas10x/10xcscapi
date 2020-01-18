using System;
using System.Threading.Tasks;
using Application.Session;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class OrdersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Order>> Create (AddOrder.Command command)
        {
            // return await Mediator.Send(command);
            var order = await Mediator.Send(command);
            return Ok(order);
        }   
    }
}