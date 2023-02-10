using BulbasaurAPI.DTOs.Caregiver;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using BulbasaurAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using BulbasaurAPI.Authorization;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaregiverController : ControllerBase
    {
        private readonly ICaregiverRepository _caregiver;
        private readonly IChildrenRepository _children;
        private readonly IGroupRepository _group;
        private readonly IUserRepository _user;

        public CaregiverController(ICaregiverRepository caregiver, IChildrenRepository children, IGroupRepository groups, IUserRepository user)
        {
            _children = children;
            _caregiver = caregiver;
            _group = groups;
            _user = user;
        }

        // GET: api/GetAll
        [HttpGet]
        [Route("GetAll")]
        [Authorize(AccessLevel = UserAccessLevel.ADMIN)]
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
        [Authorize(AccessLevel = UserAccessLevel.ADMIN)]
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
        [Authorize(AccessLevel = UserAccessLevel.SEMIADMIN)]
        public async Task<IActionResult> CreateCaregiverAsync([FromBody] Caregiver createdCareGiver)
        {
            if (createdCareGiver == null) return BadRequest(ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newCaregiver = await _caregiver.Create(createdCareGiver);

            var newUser = await _user.RegisterUserWithPerson(newCaregiver, RandomPassword.GenerateRandomPassword());

            if (newUser != null)
            {
                return Ok("Successfully created");
            }
            else
            {
                return BadRequest("Email invalid");
            }
        }

        //Delete
        [HttpDelete]
        [Authorize(AccessLevel = UserAccessLevel.SEMIADMIN)]
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
        [Authorize(AccessLevel = UserAccessLevel.SEMIADMIN)]
        public async Task<IActionResult> UpdateCaregiverById(int caregiverId, [FromBody] CaregiverDTO updateCaregiver)
        {
            if (_caregiver.EntityExists(caregiverId) == null) return BadRequest(ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

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

                await _caregiver.Update(existingCaregiver);
            }
            else
            {
                NotFound("Cant find the specified ID");
            }

            return Ok("Successfully updated");
        }

        // Post
        [HttpPost]
        [Route("CreateCaregiversAndChild")]
        [Authorize(AccessLevel = UserAccessLevel.SEMIADMIN)]
        public async Task<ActionResult<CaregiverChildOutDTO>> CreateCaregiversAndChild([FromBody] CaregiverChildDTO ccDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_caregiver.CaregiverExists(ccDTO.Caregivers)) return BadRequest("Person är redan registrerad..");
            if (await _children.ChildExists(ccDTO.Child)) return BadRequest("Barnet är redan registrerat");

            var newChild = new Child(ccDTO);

           
     

            var addGroup = await _group.GetAll();
            newChild.Groups.AddRange(addGroup.Where(item => item.Name == "Allmän"));

            if(ccDTO.Child.EligebableGroups != null) 
            { 
            foreach (var item in ccDTO.Child.EligebableGroups)
            {
                var g = await _group.GetById(item);
                if(g != null) newChild.Groups.Add(g);

            }
            }
            var child = await _children.Create(newChild);

            var caregivers = (ccDTO.Caregivers.Select(i => new Caregiver(i))).ToList();

            var caregiversOut = new List<Caregiver>();

            foreach (Caregiver c in caregivers)

            {
                var newCg = await _caregiver.Create(c);
                caregiversOut.Add(newCg);
                c.Groups.AddRange(addGroup.Where(item => item.Name == "Allmän"));
                await _caregiver.ConnectCaregiverAndChild(newCg, newChild);

                var user = await _user.RegisterUserWithPerson(c, RandomPassword.GenerateRandomPassword(), false);

                if (user == null) return BadRequest("User can't be registered");
            }
            await _caregiver.SaveChanges();
            var outDTO = new CaregiverChildOutDTO(caregiversOut, child);

            return Ok(outDTO);
        }
    }
}