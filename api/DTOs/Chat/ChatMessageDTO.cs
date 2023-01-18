using BulbasaurAPI.Models;

namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatMessageDTO
    {
        public int? ChatId { get; set; }
        public ChatUserDTO Sender { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatMessageDTO(ChatItem chatItem)
        {
            Sender = new ChatUserDTO(chatItem.Author);
            Content = chatItem.Message;
            Timestamp = chatItem.DateTime;
        }
    }
}