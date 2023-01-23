using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonellController : ControllerBase
    {
        private readonly IPersonellRepository _personell;

        public PersonellController(IPersonellRepository personell)
        {
            _personell = personell;
        }

        // GET: api/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAllPersonell()
        {
            try
            {
                if (_personell != null)
                {
                    return Ok(_personell.GetAll());
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        // GET: api/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPersonellById(int id)
        {
            try
            {
                var personell = await _personell.GetById(id);
                if (personell != null)
                {
                    return Ok(personell);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> CreatePersonellAsync([FromBody] Personell createdPersonell)
        {
            if (createdPersonell == null) return BadRequest(ModelState);

            var checkForExistingPersonell = _personell.EntityExists(createdPersonell.Id);

            if (checkForExistingPersonell != null)
            {
                ModelState.AddModelError("", "Personell already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _personell.Create(createdPersonell);

            return Ok("Successfully created");
        }

        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeletePersonellById(int id)
        {
            var personellToDelete = _personell.EntityExists(id);
            if(personellToDelete == null)  return BadRequest(ModelState);

            await _personell.Delete(personellToDelete);
            return Ok("Successfully deleted");
        }

        //Put(Update)
        [HttpPut]
        public async Task<IActionResult> UpdatePersonellById(int id, [FromBody] Personell updatedPersonell)
        {
            if (_personell.EntityExists(id) == null) return BadRequest(ModelState);

            if (updatedPersonell == null) return BadRequest(ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingPersonell = await _personell.GetById(id);

            if (existingPersonell != null)
            {
                existingPersonell.FirstName = updatedPersonell.FirstName;
                existingPersonell.LastName = updatedPersonell.LastName;
                existingPersonell.PhoneNumber = updatedPersonell.PhoneNumber; 
                existingPersonell.HomeAddress = updatedPersonell.HomeAddress;
                existingPersonell.EmailAddress = updatedPersonell.EmailAddress;
                existingPersonell.Employment = updatedPersonell.Employment;
                existingPersonell.Role = updatedPersonell.Role;
                existingPersonell.FullTimeEmployment = updatedPersonell.FullTimeEmployment;

                await _personell.Update();
            }

            else
            {
                NotFound();
            }
            return Ok("Successfully updated");           
        }
    }
}
