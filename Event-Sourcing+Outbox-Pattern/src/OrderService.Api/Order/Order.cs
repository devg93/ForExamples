using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using OrderService.Application;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order(IMediator mediatR) : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null");
            }


            return Ok(await mediatR.Send(order));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {

            return Ok("Order details for " + id);
        }
    }
}
