using BulbasaurAPI.Authorization;
using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using BulbasaurAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BulbasaurAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        // GET: api/user/getall
        [HttpGet]
        [Route("getallchatusers")]
        public async Task<ActionResult<IEnumerable<ChatUserDTO>>> GetAllAsChatUser(string? filter)
        {
            var user = HttpHelper.GetRequestUser(HttpContext);

            var users = (List<User>)await _user.GetAll();

            // Remove potential admin accounts
            users.RemoveAll(u => u.Person == null);

            if (!string.IsNullOrEmpty(filter))
            {
                users = users.Where(u =>
                   u.Person.FullName.Contains(filter) || (u.Person.Role != null ? u.Person.Role.Name.Contains(filter) : false)).ToList<User>();
            }

            // Convert to charuser DTO
            IEnumerable<ChatUserDTO> chatUsers = users.Select(u => new ChatUserDTO(u));

            return Ok(chatUsers);
        }
    }
}