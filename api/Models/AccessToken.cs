using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public class AccessToken
    {
        public int Id { get; set; }

        // Hashed token
        [MaxLength(64)]
        public string Token { get; set; }

        [MaxLength(40)]
        public string IpAddress { get; set; }

        public User User { get; set; }
        public DateTime IssuedDateTime { get; set; }
        public DateTime LastUsedDateTime { get; set; }

        [NotMapped]
        public static int MaximumIdleMinutes { get; set; } = 60;

        [NotMapped]
        public static int MaximumSessionMinutes { get; set; } = 120;
    }
}