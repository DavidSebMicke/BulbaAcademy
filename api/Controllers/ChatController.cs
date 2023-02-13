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

                if (!chat.InvolvedUsersList.Any(u => u.Id == user.Id)) return Unauthorized("Du har inte tillgång till denna chat.");

                return Ok(new ChatDTO(chat, user));
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
                var user = HttpHelper.GetRequestUser(HttpContext);
                var chatList = await _chat.GetChats(user);
                var chatDTOs = chatList.Select(chat => new ChatInfoDTO(chat, user)).ToList();

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

            var newChat = await _chat.CreateChat(new());

            var chatItem = new ChatItem() { Message = newChatDTO.Message };
            var newChatItem = await _chat.CreateChatItem(chatItem);
            newChatItem.Author = user;
            await _chat.SaveChangesAsync();

            newChat.InvolvedUsersList = users;
            newChat.ChatItemList = new List<ChatItem> { newChatItem };

            await _chat.UpdateChat(newChat);

            await _chat.SaveChangesAsync();

            var chatWithPersonData = await _chat.Get(newChat.Id);

            return Ok(new ChatDTO(chatWithPersonData, user));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        // POST: api/chat/send
        [HttpPost]
        [Route("send")]
        public async Task<ActionResult<ChatDTO?>> SendMessage([FromBody] ChatMessageDTO chatMessage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = (User)HttpContext.Items["User"];

            var chat = await _chat.Get(chatMessage.ChatId, user);

            if (chat == null) return Unauthorized("Du har inte tillgång till denna chatt.");

            chat.ChatItemList.Add(new(chatMessage, user));
            var updatedChat = await _chat.UpdateChat(chat);
            await _chat.SaveChangesAsync();

            var chatWithPersonData = await _chat.Get(updatedChat.Id);

            return Ok(new ChatDTO(chatWithPersonData, user));
        }
    }
}