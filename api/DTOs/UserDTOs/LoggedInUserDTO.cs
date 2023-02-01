using BulbasaurAPI.Authorization;
using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.UserDTOs
{
    public class LoggedInUserDTO
    {
        public int Id { get; set; }

        [MaxLength(255, ErrorMessage = "Emailadressen är för lång.")]
        [MinLength(5, ErrorMessage = "Emailadressen är för kort.")]
        [EmailAddress(ErrorMessage = "Ogiltig emailadress.")]
        public string Username { get; set; }

        public UserAccessLevel AccessLevel { get; set; }

        public LoggedInUserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            AccessLevel = user.AccessLevel;
        }
    }
}
