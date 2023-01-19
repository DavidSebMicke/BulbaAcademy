using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
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

                return Ok(_caregiver.GetAll());
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
                return Ok(_caregiver.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCaregiverAsync([FromBody] Caregiver caregiverCreate)
        {
            if (caregiverCreate == null) return BadRequest(ModelState);

            var caregivers = _caregiver.EntityExists(caregiverCreate.Id);
           


            if (caregivers != null)
            {
                ModelState.AddModelError("", "Caregiver already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);


            await _caregiver.Create(caregiverCreate);

            return Ok("Successfully created");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCaregiverById([FromQuery] int id)
        {
            var caregiverDelete = _caregiver.EntityExists(id);
            if (caregiverDelete == null) return BadRequest(ModelState);



            await _caregiver.Delete(caregiverDelete);

            return Ok("Successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCaregiverById(int caregiverId, [FromBody] Caregiver updateCaregiver)
        {
            if (_caregiver.EntityExists(caregiverId) == null) return BadRequest(ModelState);
          
            if (updateCaregiver == null)
                return BadRequest(ModelState);
            if (caregiverId != updateCaregiver.Id) 
                return BadRequest(ModelState);
            

            if (!ModelState.IsValid)
                return BadRequest();

            var existingCaregiver = await _caregiver.GetById(updateCaregiver.Id);

            if (existingCaregiver != null)
            {
                existingCaregiver.FirstName = updateCaregiver.FirstName;
                existingCaregiver.LastName = updateCaregiver.LastName;
                existingCaregiver.PhoneNumber = updateCaregiver.PhoneNumber;
                existingCaregiver.HomeAddress = updateCaregiver.HomeAddress;
                existingCaregiver.EmailAddress = updateCaregiver.EmailAddress;
                existingCaregiver.SSN = updateCaregiver.SSN;

                await _caregiver.Update();
            }
            else
            {
                NotFound();
            }
            return Ok("Successfully updated");
        }

    }
}