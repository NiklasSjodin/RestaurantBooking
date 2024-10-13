using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Data;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(RestaurantContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterUserDTO registerUser)
        {
            var existingUser = _context.Accounts.FirstOrDefault(u => u.Email == registerUser.Email);

            if(existingUser != null)
            {
                return BadRequest("Email is already in use");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            var newAccount = new Account
            {
                Email = registerUser.Email,
                PasswordHash = passwordHash
            };

            _context.Accounts.Add(newAccount);
            _context.SaveChanges();

            return Ok();
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginUserDTO loginUser)
        {
            var user = _context.Accounts.SingleOrDefault(u => u.Email == loginUser.Email);

            if(user == null || !BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid Email or Password");
            }
            var token = GenerateJwtToken(user);

            return Ok(new {token});
        }

        private string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Email, account.Email)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
