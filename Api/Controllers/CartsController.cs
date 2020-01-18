using Application.Shop;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class CartsController : BaseController
    {
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<CartDto>>> List(Guid id)
        {
            return await Mediator.Send(new ListCart.Query{Id = id});
        }
        [HttpPost]
        public async Task<ActionResult<Cart>> Create (AddCart.Command command)
        {
            // return await Mediator.Send(command);
            var cart = await Mediator.Send(command);
            return Ok(cart);
        }
        [HttpPut]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> Update (UpdateCart.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Remove(long id)
        {
            return await Mediator.Send(new RemoveCart.Command{Id = id});
        }
    }
}