using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly IPersonRepository _person;

        public PeopleController(IPersonRepository context)
        {
            _person = context;
        }

        // GET: api/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _person.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                if (!await _person.EntityExists(id))
                {
                    return NotFound("Cant find the specified ID");
                    
                }

                return Ok(await _person.GetById(id));
            }
            catch (Exception)
            {
               throw;
            }
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync([FromBody] Person createdPerson)
        {
            if (createdPerson == null) return BadRequest(ModelState);

            var personExists = await _person.EntityExists(createdPerson.Id);

            if (personExists)
            {
                ModelState.AddModelError("", "Person already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _person.Create(createdPerson);

            return Ok("Successfully created");
        }


        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeletePersonById(int id)
        {
            var personExists = await _person.EntityExists(id);
            if (!personExists) return NotFound("A person with the given ID does not exist.");
            var personToDelete = await _person.GetById(id);
            if (personToDelete == null) return NotFound("A person with the given ID does not exist.");

            await _person.Delete(personToDelete);

            return Ok("Successfully deleted");
        }

        //Put(Update)
        [HttpPut]
        public async Task<IActionResult> UpdatePersonById(int personId, [FromBody] Person updatePerson)
        {
            if (_person.EntityExists(personId) == null) return BadRequest(ModelState);

            if (updatePerson == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var existingPerson = await _person.GetById(personId);

            if (existingPerson != null)
            {
                existingPerson.FirstName = updatePerson.FirstName;
                existingPerson.LastName = updatePerson.LastName;
                existingPerson.PhoneNumber = updatePerson.PhoneNumber;
                existingPerson.HomeAddress = updatePerson.HomeAddress;
                existingPerson.EmailAddress = updatePerson.EmailAddress;
               

                await _person.Update(existingPerson);
            }
            else
            {
                NotFound("Cant find the specified ID");
            }

            return Ok("Successfully updated");
        }



    }
}