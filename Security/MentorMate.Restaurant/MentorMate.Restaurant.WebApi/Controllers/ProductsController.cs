using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();

            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{productId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetProduct([FromRoute] int productId)
        {
            var product = await _productService.GetByIdAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.AddAsync(model);

            if (!response.Result)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.UpdateAsync(model);

            if (!response.Result)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{productId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var response = await _productService.DeleteAsync(productId);

            if (!response.Result)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
