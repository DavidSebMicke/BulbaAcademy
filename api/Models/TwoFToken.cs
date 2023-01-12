using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public class TwoFToken : Token
    {

        [NotMapped]
        public static int MaximumIdleMinutes { get; set; } = 2;

        [NotMapped]
        public static int MaximumSessionMinutes { get; set; } = 2;
    }
}