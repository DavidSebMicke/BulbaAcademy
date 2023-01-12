using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public abstract class Token
    {
        public int Id { get; set; }

        // Hashed token
        [MaxLength(64)]
        public string TokenStr { get; set; }

        [MaxLength(40)]
        public string IpAddress { get; set; }

        public User User { get; set; }
        public DateTime IssuedDateTime { get; set; }
        public DateTime LastUsedDateTime { get; set; }




    }
}
