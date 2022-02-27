using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Auth;
using MentorMate.Restaurant.WebApi.Configurations.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
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

        [HttpPost]
        public async Task<IActionResult> AuthorizeAsync([FromForm] AuthorizeRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest(new AuthorizeErrorResponse(Messages.LoginErrorMessage));
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!signInResult.Succeeded)
            {
                return BadRequest(new AuthorizeErrorResponse(Messages.LoginErrorMessage));
            }

            var response = new AuthorizeResponse
            {
                AccessToken = await GetAccessTokenAsync(user),
                TokenType = "Bearer",
                ExpiresIn = _options.TokenLifetimeSeconds
            };

            return Ok(response);
        }

        private async Task<string> GetAccessTokenAsync(User user)
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
