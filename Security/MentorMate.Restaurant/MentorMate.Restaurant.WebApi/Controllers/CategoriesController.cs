using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.WebApi.Services;
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
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();

            if(!categories.Any())
            {
                return NotFound();
            }

            var response = Mapper.MapCategoryCollection(categories);

            return Ok(response);
        }

        [HttpGet("{categoryId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetCategory([FromRoute] int categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            var response = Mapper.MapCategory(category);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryModel model)
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

            return Ok(response);
        }

        [HttpPut("{categoryId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromForm] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.UpdateAsync(categoryId, model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{categoryId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteCategory([FromRoute] int categoryId)
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
