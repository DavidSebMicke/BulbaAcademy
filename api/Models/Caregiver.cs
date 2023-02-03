using BulbasaurAPI.DTOs.Caregiver;

namespace BulbasaurAPI.Models
{
    public class Caregiver : Person
    {
        public List<Child>? Children { get; set; } = new List<Child>();
        public Caregiver()
        {

        }
        public Caregiver(CaregiverDTO caregiverDTO)
        {
            SSN = caregiverDTO.SSN;
            FirstName = caregiverDTO.FirstName;
            LastName = caregiverDTO.LastName;
            HomeAddress = caregiverDTO.HomeAddress;
            PhoneNumber = caregiverDTO.PhoneNumber;
            EmailAddress = caregiverDTO.EmailAddress;
           

        }
    }

}