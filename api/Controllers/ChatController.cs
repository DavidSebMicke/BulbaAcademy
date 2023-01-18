using BulbasaurAPI.DTOs.Chat;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository;
using BulbasaurAPI.Repository.Chat;
using Microsoft.AspNetCore.Mvc;

namespace BulbasaurAPI.Controllers
{
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
        public async Task<ChatDTO?> Get([FromQuery] int id)
        {
            var user = (User)HttpContext.Items["User"];
            return await _chat.Get(user, id);
        }

        // GET: api/chat/list
        [HttpGet]
        [Route("list")]
        public async Task<ICollection<ChatInfoDTO>?> GetChats()
        {
            var user = (User)HttpContext.Items["User"];
            return await _chat.GetChats(user);
        }

        // POST: api/chat/create
        [HttpPost]
        [Route("create")]
        public async Task<ChatDTO?> CreateChat([FromBody] NewChatDTO newChat)
        {
            var user = (User)HttpContext.Items["User"];
            return await _chat.CreateChat(user, newChat);
        }

        // POST: api/chat/send
        [HttpPost]
        [Route("send")]
        public async Task<ChatDTO?> SendMessage(ChatMessageDTO chatMessage)
        {
            var user = (User)HttpContext.Items["User"];
            return await _chat.SendMessage(user, chatMessage);
        }
    }
}