using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulbasaurAPI.Models
{
    public class Logging
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Action { get; set; }

        [AllowNull]
        public User? User { get; set; }

        [MaxLength(128)]
        public string IpAddress { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}