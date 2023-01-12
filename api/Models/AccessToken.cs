using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public class AccessToken : Token
    {

        [NotMapped]
        public static int MaximumIdleMinutes { get; set; } = 60;

        [NotMapped]
        public static int MaximumSessionMinutes { get; set; } = 120;
    }
}