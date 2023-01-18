using BulbasaurAPI.Models;

namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ChatUserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.Person.FirstName;
            LastName = user.Person.LastName;
        }
    }
}