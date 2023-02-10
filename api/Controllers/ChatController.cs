using BulbasaurAPI.Authorization;
using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;
using BulbasaurAPI.Repository.Interface;
using BulbasaurAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Controllers
{
    [Authorize(AccessLevel = UserAccessLevel.USER)]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chat;

        public ChatController(IChatRepository context)
        {
            _chat = context;
        }

        // GET: api/chat
        [HttpGet]
        public async Task<ActionResult<ChatDTO?>> Get([FromQuery] int id)
        {
            try
            {
                var user = (User)HttpContext.Items["User"];
                var chat = await _chat.Get(id);

                if (!chat.InvolvedUsersList.Contains(user)) return Unauthorized("Du har inte tillgång till denna chat.");

                return Ok(new ChatDTO(chat));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/chat/list
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<ICollection<ChatInfoDTO>>> GetChats()
        {
            try
            {
                var user = (User)HttpContext.Items["User"];
                var chatList = await _chat.GetChats(user);
                var chatDTOs = chatList.Select(chat => new ChatDTO(chat)).ToList();

                return Ok(chatDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/chat/create
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ChatDTO?>> CreateChat([FromBody] NewChatDTO newChatDTO)
        {
            //try
            //{
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = HttpHelper.GetRequestUser(HttpContext);
            if (user == null) return Unauthorized("Missing user.");

            var users = await _chat.GetUsersByIds(newChatDTO.Users);
            users.Add(user);

            var chatItems = new List<ChatItem>()
                {
                    new ChatItem() { Author = user, Message = newChatDTO.Message }
                };

            var newChat = new Chat(users, chatItems);

            var newEntry = await _chat.CreateChat(newChat);
            await _chat.SaveChangesAsync();

            return Ok(new ChatDTO(newEntry));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        // POST: api/chat/send
        [HttpPost]
        [Route("send")]
        public async Task<ActionResult<ChatDTO?>> SendMessage(ChatMessageDTO chatMessage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = (User)HttpContext.Items["User"];

            var chat = await _chat.Get(chatMessage.ChatId);

            if (!chat.InvolvedUsersList.Contains(user)) return Unauthorized("Du har inte tillgång till denna chatt.");

            chat.ChatItemList.Add(new(chatMessage, user));
            var updatedChat = await _chat.UpdateChat(chat);
            await _chat.SaveChangesAsync();

            return Ok(new ChatDTO(updatedChat));
        }
    }
}