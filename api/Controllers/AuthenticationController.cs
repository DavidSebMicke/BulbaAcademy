using BulbasaurAPI.Authentication;
using BulbasaurAPI.Helpers;
using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DbServerContext _context;

        public AuthenticationController(DbServerContext context)
        {
            _context = context;
        }
        
        [HttpGet("login")]
        public async Task<ActionResult<string>> Login(string givenEmail, string givenPassword)
        {
            var user = await _context.Users.Where(x => x.Username == givenEmail).FirstOrDefaultAsync();

            if (user == null) return BadRequest("User not found.");
            else
            {

                if (Hasher.Verify(givenPassword, user.Password))
                {
                    return await TokenUtils.GenerateTwoFToken(user, HttpHelper.GetIpAddress(HttpContext), _context);
                }
                else return BadRequest("Wrong password");
            }
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<User>> CreateUser(string email, string password)
        {
            if(!InputValidator.ValidateEmailFormat(email)) return BadRequest("Not a valid email");
            if (!InputValidator.ValidatePasswordFormat(password)) return BadRequest("Not a valid password");

            User newUser = new User()
            {
                Username = email,
                Password = Hasher.Hash(password),
                AccessLevel = Authorization.UserAccessLevel.ADMIN
            };

            if (await _context.Users.AnyAsync(u => u.Username == email))
            {
                return BadRequest("User already exists");
            }
            else
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
        }
    }
}