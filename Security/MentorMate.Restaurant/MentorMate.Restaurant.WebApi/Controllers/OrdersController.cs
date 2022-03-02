using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
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

        public OrdersController(IOrderService orderService, IOrderRepository orderRepo)
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

            return Ok(orders);
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

            return Ok(order);
        }

        [HttpDelete("{orderId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int orderId)
        {
            var response = await _orderService.DeleteAsync(orderId);

            if (!response.Result)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
