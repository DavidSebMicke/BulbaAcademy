using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class LogInForm
    {
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }
    }
}