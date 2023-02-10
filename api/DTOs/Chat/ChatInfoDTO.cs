using BulbasaurAPI.Models;

namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatInfoDTO
    {
        public int ChatId { get; set; }
        public List<ChatUserDTO> Users { get; set; }
        public ChatMessageDTO LastMessage { get; set; }

        public ChatInfoDTO(Models.Chat chat, User user)
        {
            ChatId = chat.Id;
            Users = new();
            LastMessage = new ChatMessageDTO(chat.ChatItemList.Last());

            chat.InvolvedUsersList.ForEach(u =>
            {
                if (u.Id != user.Id) Users.Add(new ChatUserDTO(u));
            });
        }
    }
}