using BulbasaurAPI.Authentication;
using BulbasaurAPI.DTOs.Tokens;
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
        
        [HttpPost("login")]
        public async Task<ActionResult<PasswordLogInResponse>> Login([FromBody] LogInForm logInForm)
        {

            var user = await _context.Users.Where(x => x.Username == logInForm.Email).FirstOrDefaultAsync();

            if (user == null) return Unauthorized("User not found");
            else
            {

                if (Hasher.Verify(logInForm.Password, user.Password))
                {
                    return new PasswordLogInResponse
                    {
                        TwoFToken = await TokenUtils.GenerateTwoFToken(user, HttpHelper.GetIpAddress(HttpContext), _context)
                    };
                     
                }
                else return Unauthorized("Wrong password");
            }
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<User>> CreateUser(string email, string password)
        {
            //checks if email format is valid
            if(!InputValidator.ValidateEmailFormat(email)) return BadRequest("Not a valid email");
            //checks if password format is valid
            if (!InputValidator.ValidatePasswordFormat(password)) return BadRequest("Not a valid password");


            //checks if user already exists
            if (await _context.Users.AnyAsync(u => u.Username == email))
            {

                return BadRequest("User already exists");
            }
            else
            {

                User newUser = new User()
                {
                    Username = email,
                    Password = Hasher.Hash(password),
                    AccessLevel = Authorization.UserAccessLevel.ADMIN
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
        }
    }
}