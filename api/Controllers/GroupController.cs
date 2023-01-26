using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groups;
        //private readonly IPersonRepository _persons;

        public GroupController(IGroupRepository groups/*, IPersonRepository persons*/)
        {
            _groups = groups;
            //_persons = persons;
        }

        [HttpGet]
        [Route("GetGroupByPersonID")]
        public async Task<IActionResult> GetGroupsByPersonId(int id)
        {

            
            var result = await _groups.GetGroupsByPersonId(id);
           
            return Ok(result);
        }
    }
}
