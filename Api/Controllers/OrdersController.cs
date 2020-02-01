using System;
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
        [HttpPost]
        public async Task<ActionResult<Order>> Create (AddOrder.Command command)
        {
            // return await Mediator.Send(command);
            var order = await Mediator.Send(command);
            return Ok(order);
        }   
        //  [HttpGet("{id}")]
        [Authorize]
        [HttpPut("finish")]
        public async Task<ActionResult<Unit>> Finish (FinishOrder.Command command)
        {
            return await Mediator.Send(command);
        }   
        // [HttpGet("citys/{id}")]
        // public async Task<ActionResult<List<CityDto>>> City(long id)
        // {
        //     return await Mediator.Send(new AddressCities.Query{Id = id});
        // }
        // [HttpDelete("{id}/attend")]
        // public async Task<ActionResult<Unit>> Unattend(Guid id)
        // {
        //     return await Mediator.Send(new Unattend.Command { Id = id });
        // }
    }
}