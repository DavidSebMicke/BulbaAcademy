using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildrenRepository _children;

        public ChildrenController(IChildrenRepository context)
        {
            _children = context;
        }

        // GET: api/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var children = await _children.GetAll();
                if (!children.Any()) return NoContent();

                return Ok(children);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChildById(int id)
        {
            try
            {
                if (!await _children.EntityExists(id))
                {
                    return NotFound("Cant find the specified ID");
                }

                return Ok(await _children.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> CreateChildAsync([FromBody] Child createdChild)
        {
            if (createdChild == null) return BadRequest(ModelState);

            var childExists = await _children.EntityExists(createdChild.Id);

            if (childExists)
            {
                ModelState.AddModelError("", "Child already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _children.Create(createdChild);

            return Ok("Successfully created");
        }

        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteChildById(int id)
        {
            var childExists = await _children.EntityExists(id);
            if (!childExists) return NotFound("A child with the given ID does not exist.");
            var childToDelete = await _children.GetById(id);
            if (childToDelete == null) return NotFound("A child with the given ID does not exist.");

            await _children.Delete(childToDelete);

            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChildById(int childId, [FromBody] Child updateChild)
        {
            if (_children.EntityExists(childId) == null) return BadRequest(ModelState);

            if (updateChild == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var existingChild = await _children.GetById(childId);

            if (existingChild != null)
            {
                existingChild.FirstName = updateChild.FirstName;
                existingChild.LastName = updateChild.LastName;
                existingChild.PhoneNumber = updateChild.PhoneNumber;
                existingChild.HomeAddress = updateChild.HomeAddress;
                existingChild.EmailAddress = updateChild.EmailAddress;

                await _children.Update(updateChild);
            }
            else
            {
                NotFound("Cant find the specified ID");
            }

            return Ok("Successfully updated");
        }
    }
}