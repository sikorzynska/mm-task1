using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Users;
using MentorMate.Restaurant.WebApi.Extensions;
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
        public async Task<IActionResult> GetAll()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var users = await _userService.GetAllAsync(currentUserId);

            if(!users.Any())
            {
                return NotFound(users);
            }

            var response = MapExtension.MapUserCollection(users);

            response.ToList().ForEach(x => x.Role = _userService.GetRoleAsync(x.Id).Result);

            return Ok(response);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Get([FromRoute] string userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound(user);
            }

            var response = MapExtension.MapUser(user);

            response.Role = await _userService.GetRoleAsync(userId);

            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Me()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var user = await _userService.GetByIdAsync(currentUserId);

            if (user == null)
            {
                return NotFound(user);
            }

            var response = MapExtension.MapUser(user);

            response.Role = await _userService.GetRoleAsync(user.Id);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create([FromBody] CreateUserModel model)
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

            return CreatedAtAction(nameof(Get), new { userId = response.EntityId }, response);
        }

        [HttpPut("{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update([FromRoute] string userId, [FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.UpdateAsync(userId, model);

            if (!response.Success)
            {
                if(response.Message == Messages.UserNotFound)
                {
                    return NotFound(response);
                }

                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete([FromRoute] string userId)
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
