namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatInfoDTO
    {
        public int ChatId { get; set; }
        public List<ChatUserDTO> Users { get; set; }
        public ChatMessageDTO LastMessage { get; set; }

        public ChatInfoDTO(Models.Chat chat)
        {
            ChatId = chat.Id;
            Users = (List<ChatUserDTO>)chat.InvolvedUsersList.Select(u => new ChatUserDTO(u));
            LastMessage = new ChatMessageDTO(chat.ChatItemList.Last());
        }
    }
}