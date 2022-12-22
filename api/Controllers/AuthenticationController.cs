using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<string>> Login(string givenEmail, string givenPassword)
        {
            var user = await _context.Users.Where(x => x.Username == givenEmail).FirstOrDefaultAsync();

            if (user == null) return BadRequest("User not found.");

            else
            {
                if(Hasher.Verify(givenPassword, user.Password))
                {
                    
                    return "dunno something?";
                }
                else return BadRequest("Wrong password");
            }

        }


        

    }
}
