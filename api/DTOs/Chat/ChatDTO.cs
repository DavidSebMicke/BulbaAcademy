using BulbasaurAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatDTO
    {
        public int ChatId { get; set; }
        public List<ChatUserDTO> Users { get; set; }
        public List<ChatMessageDTO> Messages { get; set; }

        public ChatDTO(Models.Chat chat, User user)
        {
            ChatId = chat.Id;
            Users = new();
            Messages = new();

            chat.InvolvedUsersList.ForEach(u =>
            {
                if (u.Id != user.Id) Users.Add(new ChatUserDTO(u));
            });

            chat.ChatItemList.ForEach(chatItem =>
            {
                Messages.Add(new ChatMessageDTO(chatItem));
            });
        }
    }
}