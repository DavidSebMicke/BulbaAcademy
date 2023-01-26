using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Tokens
{
    public class PasswordLogInResponse
    {
        [MaxLength(1024)]
        public string TwoFToken { get; set; }
    }
}