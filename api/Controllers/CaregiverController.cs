using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;
using Microsoft.AspNetCore.Mvc;


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

                return Ok(_caregiver.GetAllCaregivers());
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
                return Ok(_caregiver.GetCaregiverById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargegiver([FromBody] Caregiver caregiverCreate, [FromQuery] int childId)
        {
            if (caregiverCreate == null) return BadRequest(ModelState);

            var caregivers = _caregiver.GetAllCaregivers().Where(c => c.Id == caregiverCreate.Id).FirstOrDefault();

            if (caregivers != null)
            {
                ModelState.AddModelError("", "Caregiver already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_caregiver.CreateCaregiver(childId, caregiverCreate))
            {
                ModelState.AddModelError("", "Something went wrong wihle saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }




    }
}