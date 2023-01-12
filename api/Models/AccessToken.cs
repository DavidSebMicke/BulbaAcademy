using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public class AccessToken : Token
    {


        public AccessToken()
        {
            MaximumIdleMinutes = 60;

            MaximumSessionMinutes = 120;
        }


    }
}