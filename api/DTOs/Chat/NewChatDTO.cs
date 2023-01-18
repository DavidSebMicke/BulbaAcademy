namespace BulbasaurAPI.DTOs.Chat
{
    public class NewChatDTO
    {
        public List<ChatUserDTO> Users { get; set; }
        public string Message { get; set; }
    }
}