using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs
{
    // Received from frontend
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string TwoFactorCode { get; set; }

        [Required]
        public string GrantType { get; set; }
    }
}