using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Models.Categories;
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

            return Ok(categories);
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

            return Ok(category);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.AddAsync(model);

            if (!response.Result)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _categoryService.UpdateAsync(model);

            if (!response.Result)
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

            if (!response.Result)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
