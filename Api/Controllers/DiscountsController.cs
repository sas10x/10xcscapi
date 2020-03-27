using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Discounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class DiscountsController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<DiscountDto>>> Details(long id)
        {
            return await Mediator.Send(new DiscountGrade.Query{Id = id});
        }
        [Authorize(Policy = "IsUser")]
        [HttpPost]
        public async Task<ActionResult<Unit>> Create (CreateDiscount.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}