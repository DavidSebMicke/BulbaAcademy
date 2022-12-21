using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverController : ControllerBase
    {
        
        private readonly ICaregiverRepository _context;

        public CaregiverController(CaregiverRepository context)
        {
            _context = context;
        }

        // GET: api/GetAll
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IEnumerable<Caregiver> GetAll()
        {
            try
            {
               var  all =_context.GetAllCaregivers();
                return all;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
