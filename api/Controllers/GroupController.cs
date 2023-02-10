using BulbasaurAPI.Authorization;
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
        [Authorize(AccessLevel = UserAccessLevel.SEMIADMIN)]
        public async Task<IActionResult> GetGroupsByPersonId(int id)
        {
            var result = await _groups.GetGroupsByPersonId(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllGroups")]
        public async Task<ActionResult<GroupDTOout>> GetAllGroups()
        {
            var allGroups = await _groups.GetAll();
            var dtoOut = new List<GroupDTOout>();

            foreach (var item in allGroups)
            {

                dtoOut.Add(new GroupDTOout(item));

            }
            return Ok(dtoOut);
        }

        [HttpPost]
        [Authorize(AccessLevel = UserAccessLevel.SEMIADMIN)]
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

        [HttpDelete]
        [Route("DeleteGroupById")]
        public async Task<ActionResult> DeleteGroupById(int id)
        {
            var exists = await _groups.EntityExists(id);
            if (!exists) return BadRequest(ModelState);  
            await _groups.DeleteGroupById(id);
           
            return Ok("Successfully removed");

        }
    }
}