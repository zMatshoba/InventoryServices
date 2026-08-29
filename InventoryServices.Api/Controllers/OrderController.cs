using InventoryServices.Application.Dtos.OrderDtos;
using InventoryServices.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {

        [HttpPut]
        public async Task<ActionResult> Put(CreateOrderDto createOrder,CancellationToken cancellationToken)
        {
            try
            {
                var response = await orderService.CreateAsync(createOrder, cancellationToken);

                if (!response.Success)
                    return UnprocessableEntity(response);

                return Created();
            }
            catch (ArgumentException ex)
            {
                return UnprocessableEntity(ex.Message);
            } 
        }
    }
}
