namespace BulbasaurAPI.Models
{
    public class Logging
    {
        public int Id { get; set; }
        public string Action { get; set; }

        public User User { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;


    }
}
