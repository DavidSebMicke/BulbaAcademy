namespace BulbasaurAPI.Models
{
    public class LogInInformation
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }

        public string LogInCountry { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string LoggedInDevice { get; set; }

        public User User { get; set; }


    }
}
