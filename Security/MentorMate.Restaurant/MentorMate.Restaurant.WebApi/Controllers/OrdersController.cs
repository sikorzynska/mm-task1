using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
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

            return Ok(orders);
        }

        //[HttpGet("{productId}")]
        //[Authorize(Roles = UserRoles.Admin)]
        //public async Task<IActionResult> GetProduct([FromRoute] int productId)
        //{
        //    var product = await _productService.GetByIdAsync(productId);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}

        //[HttpPut]
        //[Authorize(Roles = UserRoles.Admin)]
        //public async Task<IActionResult> CreateProduct([FromForm] CreateProductModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _productService.AddAsync(model);

        //    if (!response.Result)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}

        //[HttpPatch]
        //[Authorize(Roles = UserRoles.Admin)]
        //public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var response = await _productService.UpdateAsync(model);

        //    if (!response.Result)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}

        //[HttpDelete("{productId}")]
        //[Authorize(Roles = UserRoles.Admin)]
        //public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        //{
        //    var response = await _productService.DeleteAsync(productId);

        //    if (!response.Result)
        //    {
        //        return NotFound(response);
        //    }

        //    return Ok(response);
        //}
    }
}
