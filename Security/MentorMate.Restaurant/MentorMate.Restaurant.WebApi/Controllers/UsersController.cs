using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(
            UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsers()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var users = await _userManager.Users.Where(u => u.Id != currentUserId).ToListAsync();

            if(!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet()]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
        }
    }
}
