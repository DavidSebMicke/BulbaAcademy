using BulbasaurAPI.Database;
using BulbasaurAPI.DTOs.Login;
using BulbasaurAPI.DTOs.Tokens;
using BulbasaurAPI.DTOs.UserDTOs;
using BulbasaurAPI.Models;
using BulbasaurAPI.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Security.Provider;
using OtpNet;
using QRCoder;
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
                    var qr = "";
                    if (!(await _context.TOTPs.AnyAsync(x => x.Key == user.GUID)))
                    {
                        var totp = new TOTP
                        {
                            Key = user.GUID,
                            Secret = TOTPUtil.GenerateTOTPSecret(),
                            TimeWindowUsed = 0
                        };
                        string secretFull = $"otpauth://totp/Bulbasaur:{user.Username}?secret={QrUtil.ToBase32String(totp.Secret)}&issuer=Bulbasaur";
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(secretFull, QRCodeGenerator.ECCLevel.Q);
                        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
                        byte[] qrCodeImage = qrCode.GetGraphic(9);
                        qr = Convert.ToBase64String(qrCodeImage);

                        await _context.TOTPs.AddAsync(totp);
                    }

                    return new PasswordLogInResponse
                    {
                        Token = await TokenUtils.GenerateTwoFToken(user, HttpHelper.GetIpAddress(HttpContext), _context),
                        QrCode = qr
                    };
                }
                else return Unauthorized("Wrong password");
            }
        }

        [HttpPost("createUserTEST")]
        public async Task<ActionResult<User>> CreateUser(LogInForm loginForm)
        {
            var newPassword = loginForm.Password; //RandomPassword.GenerateRandomPassword();
            var newUser = await UserUtils.RegisterUser(loginForm.Email, newPassword, _context, sendEmail: false);

            if (newUser == null) return Unauthorized("not workin");
            else return newUser;
        }

        [HttpPost("login/totp")]
        public async Task<ActionResult<UserToken>> TwoFactorLogin([FromBody] TOTPIN totpIn)
        {
            var twoFEntity = await _context.TwoFTokens.Include(x => x.User).ThenInclude(x => x.Person).FirstOrDefaultAsync(x => x.TokenStr == totpIn.TwoFToken);

            if (twoFEntity == null || twoFEntity.User == null) return NotFound("User not found");

            if (!(await TokenUtils.AuthenticateTwoFToken(totpIn.TwoFToken, HttpHelper.GetIpAddress(HttpContext), _context))) return BadRequest("Invalid Token");

            var tOTP = await _context.TOTPs.Where(x => x.Key == twoFEntity.User.GUID).FirstOrDefaultAsync();

            if (tOTP == null) return NotFound("Two factor validation unavailable");

            if (TOTPUtil.VerifyTOTP(tOTP, totpIn.Code))
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