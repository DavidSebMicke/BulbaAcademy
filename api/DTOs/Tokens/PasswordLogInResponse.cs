using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Tokens
{
    public class PasswordLogInResponse
    {
        public int Id { get; set; }

        [MaxLength(1024)]
        public string Token { get; set; }

        public string? QrCode { get; set; }

    }
}