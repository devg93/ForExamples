using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order(IMediator mediatR) : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null");
            }


            return Ok("Order created successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {

            return Ok("Order details for " + id);
        }
    }
}
