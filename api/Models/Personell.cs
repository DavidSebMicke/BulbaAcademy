using System.Text.RegularExpressions;

namespace BulbasaurAPI.Models
{
    public class Personell : Person
    {
        
        public string Employment { get; set; }
        public bool FullTimeEmployment { get; set; }

    }
}
