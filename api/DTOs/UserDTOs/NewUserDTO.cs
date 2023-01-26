using BulbasaurAPI.Authorization;
using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.UserDTOs
{
    public class NewUserDTO
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string Username { get; set; }

        public UserAccessLevel AccessLevel { get; set; }

        public NewUserDTO(User user)
        {
            Id = user.Id;
            Username= user.Username;
            AccessLevel = user.AccessLevel;
        }
    }
}
