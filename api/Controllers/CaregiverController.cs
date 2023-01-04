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

                return Ok(await _caregiver.GetAllCaregiversAsync());
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
                return Ok(await _caregiver.GetCaregiverByIdAsync(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public  async Task<IActionResult> CreateCargegiver([FromBody] Caregiver caregiverCreate)
        {
            return Ok(await _caregiver.CreateCaregiverAsync(caregiverCreate));
                
           }

    }
}