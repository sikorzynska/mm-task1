using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var users = await _userService.GetAllAsync();
            var result = users.Where(u => u.Id != currentUserId).ToList();

            if(!users.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userService.GetByIdAsync(currentUserId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromForm] AddUserModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.AddUserAsync(model);

            if(!response.Result)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.UpdateUserAsync(model);

            if (!response.Result)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var response = await _userService.DeleteUserAsync(userId);

            if (!response.Result)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
