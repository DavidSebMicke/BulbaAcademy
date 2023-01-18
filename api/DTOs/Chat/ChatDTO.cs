namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatDTO
    {
        public int ChatId { get; set; }
        public List<ChatUserDTO> Users { get; set; }
        public List<ChatMessageDTO> Messages { get; set; }

        public ChatDTO(Models.Chat chat)
        {
            ChatId = chat.Id;
            Users = new();
            Messages = new();

            chat.InvolvedUsersList.ForEach(user =>
            {
                Users.Add(new ChatUserDTO(user));
            });

            chat.ChatItemList.ForEach(chatItem =>
            {
                Messages.Add(new ChatMessageDTO(chatItem));
            });
        }
    }
}