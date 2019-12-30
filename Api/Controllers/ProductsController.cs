using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Products;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductDto>> Details(long grade,  long length, long diameter)
        {
            return await Mediator.Send(new ProductDetails.Query(grade, length ,diameter));
        }

        [HttpGet("lengths")]
        public async Task<ActionResult<List<VarLength>>> Length()
        {
            return await Mediator.Send(new Varlength.Query());
        }
        [HttpGet("diameters")]
        public async Task<ActionResult<List<VarDiameter>>> Diameter()
        {
            return await Mediator.Send(new Vardiameter.Query());
        }
        [HttpGet("grades")]
        public async Task<ActionResult<List<VarGrade>>> Grade()
        {
            return await Mediator.Send(new Vargrade.Query());
        }
    }
}