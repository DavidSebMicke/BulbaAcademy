using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using BulbasaurAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverController : ControllerBase
    {
        private readonly ICaregiverRepository _caregiver;

        public CaregiverController(ICaregiverRepository context)
        {
            _caregiver = context;
        }

        // GET: api/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _caregiver.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCareGiverById(int id)
        {
            try
            {
                if (!await _caregiver.EntityExists(id))
                {
                    return NotFound("Cant find the specified ID");

                }

                return Ok(await _caregiver.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> CreateCaregiverAsync([FromBody] Caregiver createdCareGiver)
        {
            if (createdCareGiver == null) return BadRequest(ModelState);

            var caregiverExists = await _caregiver.EntityExists(createdCareGiver.Id);

            if (caregiverExists)
            {
                ModelState.AddModelError("", "Caregiver already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _caregiver.Create(createdCareGiver);

            return Ok("Successfully created");
        }

        //Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteCaregiverById(int id)
        {
            var caregiverExists = await _caregiver.EntityExists(id);
            if (!caregiverExists) return NotFound("A caregiver with the given ID does not exist.");
            var caregiverToDelete = await _caregiver.GetById(id);
            if (caregiverToDelete == null) return NotFound("A caregiver with the given ID does not exist.");

            await _caregiver.Delete(caregiverToDelete);

            return Ok("Successfully deleted");
        }

        //Put(Update)
        [HttpPut]
        public async Task<IActionResult> UpdateCaregiverById(int caregiverId, [FromBody] Caregiver updateCaregiver)
        {
            if (_caregiver.EntityExists(caregiverId) == null) return BadRequest(ModelState);

            if (updateCaregiver == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var existingCaregiver = await _caregiver.GetById(caregiverId);

            if (existingCaregiver != null)
            {
                existingCaregiver.FirstName = updateCaregiver.FirstName;
                existingCaregiver.LastName = updateCaregiver.LastName;
                existingCaregiver.PhoneNumber = updateCaregiver.PhoneNumber;
                existingCaregiver.HomeAddress = updateCaregiver.HomeAddress;
                existingCaregiver.EmailAddress = updateCaregiver.EmailAddress;
                //existingCaregiver.SSN = updateCaregiver.SSN;

                await _caregiver.Update(existingCaregiver);
            }
            else
            {
                NotFound("Cant find the specified ID");
            }

            return Ok("Successfully updated");
        }
    }
}