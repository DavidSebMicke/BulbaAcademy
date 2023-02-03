using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Tokens
{
    public class TOTPIN
    {


        [MaxLength(1024)]
        public string TwoFToken { get; set; }

        public string Code { get; set; }
    }
}
