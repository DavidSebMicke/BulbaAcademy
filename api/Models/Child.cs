using System.Text.RegularExpressions;

namespace BulbasaurAPI.Models
{
    public class Child : Person
    {
        public ICollection<CaregiverChild>? CaregiverChildren { get; set; }
    }
}
