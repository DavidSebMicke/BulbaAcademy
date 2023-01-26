using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Chat
{
    public class ChatUserDTO
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public ChatUserDTO(User user)
        {
            Id = user.Id;
            FirstName = user.Person.FirstName;
            LastName = user.Person.LastName;
        }
    }
}