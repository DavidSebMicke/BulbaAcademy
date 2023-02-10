using BulbasaurAPI.DTOs.Caregiver;
using System.Text.RegularExpressions;

namespace BulbasaurAPI.Models
{
    public class Child : Person
    {
        public List<Caregiver>? Caregivers { get; set; } = new List<Caregiver>();
        public Child()
        {

        }
        public Child(CaregiverChildDTO dto)
        {
            FirstName = dto.Child.FirstName;
            LastName = dto.Child.LastName;
            SSN = dto.Child.SSN;
            
           
        
        }
    }
}
