using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class LogInForm
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
