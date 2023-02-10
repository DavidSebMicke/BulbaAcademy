using BulbasaurAPI.DTOs.Login;
using BulbasaurAPI.DTOs.Tokens;
using BulbasaurAPI.DTOs.UserDTOs;
using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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
                if (Hasher.Verify(user.Salt + logInForm.Password, user.Password))
                {
                    return new PasswordLogInResponse
                    {
                        Token = await TokenUtils.GenerateTwoFToken(user, HttpHelper.GetIpAddress(HttpContext), _context)
                    };
                }
                else return Unauthorized("Wrong password");
            }
        }

        [HttpPost("createUserTEST")]
        public async Task<ActionResult<NewUserDTO>> CreateUser(string email, string password, bool randomizePassword)
        {
    
            var newUser = await UserUtils.RegisterUser(email, randomizePassword ? RandomPassword.GenerateRandomPassword() : password, sendEmail: true);

            if (newUser == null) return BadRequest("User was not created");
            else
            {
                return new NewUserDTO(newUser); 
            }
        }

        [HttpPost("login/totp")]
        public async Task<ActionResult<UserToken>> TwoFactorLogin([FromBody] TOTPIN totpin)
        {
            var twoFEntity = await _context.TwoFTokens.Include(x => x.User).FirstAsync(x => x.TokenStr == totpin.TwoFToken);

            if(twoFEntity == null) return NotFound("Two factor token not found");

            if (twoFEntity.User == null) return NotFound("User not found");

            //does not work 
            //if(!(await TokenUtils.AuthenticateTwoFToken(totpin.TwoFToken, totpin.Code))) return BadRequest("Token not valid");

            _context.TwoFTokens.Remove(twoFEntity);
            await _context.SaveChangesAsync();

            var tOTP = await _context.TOTPs.Where(x => x.Key == twoFEntity.User.GUID).FirstOrDefaultAsync();

            if (tOTP == null) return NotFound("Two factor validation unavailable");



            if (TOTPUtil.VerifyTOTP(tOTP, totpin.Code))
            {
                return new UserToken
                {
                    AccessToken = await TokenUtils.GenerateAccessToken(twoFEntity.User, HttpHelper.GetIpAddress(HttpContext), _context),
                    IDToken = TokenUtils.GenerateIDToken(twoFEntity.User)
                };
            }
            else
            {
                return Forbid("Wrong code");
            }
        }
    }
}