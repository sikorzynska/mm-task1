using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Sorting;
using MentorMate.Restaurant.WebApi.Extensions;
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
        public async Task<IActionResult> GetAll([FromQuery] ProductSortingModel sort)
        {
            var products = await _productService.GetAllAsync(sort);

            if (!products.Any())
            {
                return NotFound(products);
            }

            var response = MapExtension.MapProductCollection(products);

            return Ok(response);
        }

        [HttpGet("{productId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Get([FromRoute] string productId)
        {
            var product = await _productService.GetByIdAsync(productId);

            if (product == null)
            {
                return NotFound(product);
            }

            var response = MapExtension.MapProduct(product);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create([FromBody] CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.CreateAsync(model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(Get), new { productId = response.EntityId }, response);
        }

        [HttpPut("{productId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update([FromRoute] string productId, [FromBody] UpdateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.UpdateAsync(productId, model);

            if (!response.Success)
            {
                if(response.Message == Messages.ProductNotFound)
                {
                    return NotFound(response);
                }

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{productId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete([FromRoute] string productId)
        {
            var response = await _productService.DeleteAsync(productId);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
