using BulbasaurAPI.DTOs.Group;
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
        

        public GroupController(IGroupRepository groups)
        {
            _groups = groups;
        }

        [HttpGet]
        [Route("GetGroupByPersonID")]
        public async Task<IActionResult> GetGroupsByPersonId(int id)
        {
            var result = await _groups.GetGroupsByPersonId(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GroupDTOout>> PostGroup([FromBody] GroupDTO gDTO)
        {
            var newGroup = new Group(gDTO);
            if (newGroup == null) return BadRequest(ModelState);

            var groupExists = await _groups.EntityExists(newGroup.Id);

            if (groupExists)
            {
                ModelState.AddModelError("", "Group already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _groups.Create(newGroup);
            var outDTO = new GroupDTOout(newGroup);

            return Ok(outDTO);
        }
    }
}