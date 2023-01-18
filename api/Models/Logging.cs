using System.Diagnostics.CodeAnalysis;

namespace BulbasaurAPI.Models
{
    public class Logging
    {
        public int Id { get; set; }
        public string Action { get; set; }

        [AllowNull]
        public User User { get; set; }

        public string IpAddress { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}