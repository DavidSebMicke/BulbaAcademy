using BulbasaurAPI.Authentication;
using BulbasaurAPI.DTOs.Login;
using BulbasaurAPI.DTOs.Tokens;
using BulbasaurAPI.DTOs.UserDTOs;
using BulbasaurAPI.Helpers;
using BulbasaurAPI.Models;
using BulbasaurAPI.TOTPUtils;
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
        public async Task<ActionResult<User>> CreateUser(LogInForm loginForm)
        {
            var newUser = await UserUtils.RegisterUser(loginForm.Email, RandomPassword.GenerateRandomPassword(), sendEmail:true);

            if (newUser == null) return Unauthorized("not workin");
            else return newUser;
            
        }

        [HttpPost("login/totp")]
        public async Task<ActionResult<UserToken>> AccessTokenByTOTP(int userID, string code)
        {
            var tOTP = await _context.TOTPs.Where(x => x.Id == userID).FirstOrDefaultAsync();
            var user = await _context.Users.Where(x => x.Id == userID).FirstOrDefaultAsync();

            if (tOTP != null && user != null)
            {
                if (TOTPUtil.VerifyTOTP(tOTP, code))
                {
                    return new UserToken
                    {
                        Token = await TokenUtils.GenerateAccessToken(user, HttpHelper.GetIpAddress(HttpContext), _context)
                    };
                }
                else
                {
                    return Unauthorized("Wrong code");
                }
            }
            else
            {
                return Unauthorized("User not found");
            }
        }
    }
}