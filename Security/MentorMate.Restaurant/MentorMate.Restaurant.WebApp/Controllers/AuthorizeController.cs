using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Configurations.Auth;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.WebApp.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MentorMate.Restaurant.WebApp.Controllers
{
    [Controller]
    public class AuthorizeController : Controller
    {
        private readonly AuthOptions _options;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthorizeController(
            AuthOptions options,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, Messages.LoginError);

                return View(model);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, Messages.LoginError);

                return View(model);
            }

            var token = await GenerateAccessToken(user);

            //todo: implement logic for saving the jwt token in the user's browser

            return RedirectToAction("Index", "Home");
        }

        private async Task<string> GenerateAccessToken(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var signingKey = new SymmetricSecurityKey(_options.SecurityKeyAsBytes);
            var roles = await _userManager.GetRolesAsync(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(GetClaims(user, roles)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = _options.Issuer,
                Audience = _options.Audience,
                Expires = DateTime.UtcNow.AddSeconds(_options.TokenLifetimeSeconds)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private static IEnumerable<Claim> GetClaims(User user, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };

            if (roles.Any())
            {
                claims.Add(new Claim("role", roles.FirstOrDefault()));
            }

            return claims;
        }
    }
}
