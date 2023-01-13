using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DbServerContext _context;

        public GroupController(DbServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetGroupByPersonID")]
        public async Task<IActionResult> GetGroupsByPersonId(int id)
        {
            var person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
            var result = await _context.Groups
                .Where<Group>(x => x.Persons.Contains(person))
                .Include(x => x.Persons).ThenInclude(z => z.Role)
                .ToListAsync();
            return Ok(result);
        }
    }
}
