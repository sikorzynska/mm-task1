using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Models.Users;
using MentorMate.Restaurant.WebApi.Services;
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
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetUsers()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var users = await _userService.GetAllAsync(currentUserId);

            if(!users.Any())
            {
                return NotFound();
            }

            var response = Mapper.MapUserCollection(users);

            response.ToList().ForEach(x => x.Role = _userService.GetRoleAsync(x.Id).Result);

            return Ok(response);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var response = Mapper.MapUser(user);

            response.Role = await _userService.GetRoleAsync(userId);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var user = await _userService.GetByIdAsync(currentUserId);

            if (user == null)
            {
                return NotFound();
            }

            var response = Mapper.MapUser(user);

            response.Role = await _userService.GetRoleAsync(user.Id);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.CreateAsync(model);

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromForm] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.UpdateAsync(userId, model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteUser([FromRoute] string userId)
        {
            var response = await _userService.DeleteAsync(userId);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
