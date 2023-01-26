using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Chat
{
    public class NewChatDTO
    {
        public List<ChatUserDTO> Users { get; set; }

        [MaxLength(10000)]
        public string Message { get; set; }
    }
}