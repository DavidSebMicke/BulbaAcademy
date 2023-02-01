using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Login
{
    public class LogInForm
    {
        [EmailAddress(ErrorMessage = "Ogiltig emailadress.")]
        [MaxLength(255, ErrorMessage = "För lång emailadress.")]
        public string Email { get; set; }

        [MaxLength(255, ErrorMessage = "För långt lösenord.")]
        public string Password { get; set; }
    }
}