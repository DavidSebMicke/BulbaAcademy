using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs
{
    // Received from frontend
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(6)]
        public string TwoFactorCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string GrantType { get; set; }
    }
}