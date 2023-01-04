using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public class AccessToken
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Token { get; set; }

        [MaxLength(40)]
        public string IpAddress { get; set; }

        public User User { get; set; }
        public DateTime IssuedDateTime { get; set; }
        public DateTime LastUsedDateTime { get; set; }

        [NotMapped]
        public int MaximumIdleMinutes { get; set; } = 60;

        [NotMapped]
        public int MaximumSessionMinutes { get; set; } = 180;
    }
}