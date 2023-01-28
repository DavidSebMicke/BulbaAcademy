using BulbasaurAPI.DTOs.Chat;

namespace BulbasaurAPI.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public List<User> InvolvedUsersList { get; set; }
        public List<ChatItem> ChatItemList { get; set; }

        public Chat()
        { }

        public Chat(List<User> users, List<ChatItem> chatItems)
        {
            InvolvedUsersList = users;
            ChatItemList = chatItems;
        }
    }
}