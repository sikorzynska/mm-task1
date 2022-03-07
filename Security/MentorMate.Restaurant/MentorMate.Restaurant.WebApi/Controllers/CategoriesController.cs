using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            if(!categories.Any())
            {
                return NotFound(categories);
            }

            var response = Mapper.MapCategoryCollection(categories);

            return Ok(response);
        }

        [HttpGet("{categoryId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Get([FromRoute] string categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound(category);
            }

            var response = Mapper.MapCategory(category);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.CreateAsync(model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(Get), new { categoryId = response.EntityId }, response);
        }

        [HttpPut("{categoryId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update([FromRoute] string categoryId, [FromBody] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.UpdateAsync(categoryId, model);

            if (!response.Success)
            {
                if(response.Message == Messages.CategoryNotFound)
                {
                    return NotFound(response);
                }

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete([FromRoute] string categoryId)
        {
            var response = await _categoryService.DeleteAsync(categoryId);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
