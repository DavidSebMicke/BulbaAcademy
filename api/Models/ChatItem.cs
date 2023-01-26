using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class ChatItem
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public User Author { get; set; }

        [MaxLength(10000)]
        public string Message { get; set; }
    }
}