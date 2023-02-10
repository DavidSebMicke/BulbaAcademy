using BulbasaurAPI.ExternalAPIs.Recaptcha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    // Recaptcha controllor for future use
    [Route("api/[controller]")]
    [ApiController]
    public class RecaptchaController : ControllerBase
    {
        // POST: api/recaptcha
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string userToken, string? userIP)
        {
            if (await RecaptchaAPI.VerifyRecaptcha(userToken, userIP))
            {
                return Ok("Valid reCAPTCHA token.");
            }
            else
            {
                return BadRequest("Invalid reCAPTCHA token.");
            }
        }
    }
}