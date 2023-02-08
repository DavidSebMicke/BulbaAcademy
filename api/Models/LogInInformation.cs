using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class LogInInformation
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string IpAddress { get; set; }

        [MaxLength(100)]
        public string LogInCountry { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        [MaxLength(255)]
        public string LoggedInDevice { get; set; }

        public LogInStatus Status { get; set; } = LogInStatus.ACTIVE;

        public User User { get; set; }
    }

    public enum LogInStatus
    { ACTIVE, FAILED, TWOFACTORFAILED, SUCCESS };
}