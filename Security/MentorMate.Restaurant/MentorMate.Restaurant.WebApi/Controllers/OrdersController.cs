using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllAsync();

            if (!orders.Any())
            {
                return NotFound();
            }

            var response = Mapper.MapOrderCollection(orders);

            return Ok(response);
        }

        [HttpGet("{orderId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            if (order == null)
            {
                return NotFound();
            }

            var response = Mapper.MapOrder(order);

            return Ok(response);
        }

        [HttpDelete("{orderId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int orderId)
        {
            var response = await _orderService.DeleteAsync(orderId);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
