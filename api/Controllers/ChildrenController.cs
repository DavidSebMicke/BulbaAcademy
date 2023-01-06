using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly DbServerContext _context;

        public ChildrenController(DbServerContext context)
        {
            _context = context;
        }

        // GET: api/Children
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Children.ToListAsync();
            return Ok(result);
        }

        // GET api/<ChildrenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChildrenController>
        [HttpPost]
        [Route("Create")]
        public async Task<Child> Post([FromBody] Child child)
        {
            if (ModelState.IsValid)
            {

                await _context.AddAsync(child);
                await _context.SaveChangesAsync();
               
            }
            return child;
        }

        // PUT api/<ChildrenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChildrenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
