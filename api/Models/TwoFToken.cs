using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public class TwoFToken : Token
    {

        public TwoFToken(int maximumIdleMinutes = 2, int maximumSessionMinutes = 2)
        {
            MaximumIdleMinutes = maximumIdleMinutes;

            MaximumSessionMinutes = maximumSessionMinutes;
        }


    }
}