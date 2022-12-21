using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly DbServerContext _context;

        public PeopleController(DbServerContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Persons.ToListAsync();
            return Ok(result);
        }

        // GET api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = await _context.Persons
                .FirstOrDefaultAsync(x => x.Id == id); 
            return Ok(person);
        }

        // POST api/People
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/People/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/People/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}