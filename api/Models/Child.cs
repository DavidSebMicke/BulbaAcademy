using System.Text.RegularExpressions;

namespace BulbasaurAPI.Models
{
    public class Child :Person
    {
        public List<Caregiver> Caregiver { get; set; } = new List<Caregiver>();

        


    }
}
