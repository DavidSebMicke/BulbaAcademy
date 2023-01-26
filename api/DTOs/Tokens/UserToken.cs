using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Tokens
{
    // Return object for user token
    public class UserToken
    {
        [MaxLength(1024)]
        public string Token { get; set; }
    }
}