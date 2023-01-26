namespace BulbasaurAPI.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public List<User> InvolvedUsersList { get; set; }
        public List<ChatItem> ChatItemList { get; set; }
    }
}