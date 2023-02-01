using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Caregiver
{
    public class CaregiverDTO
    {

        [MinLength(12)]
        [MaxLength(12)]
        public string SSN { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public Address HomeAddress { get; set; } 

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public CaregiverDTO(Models.Caregiver caregiver)
        {
            SSN = caregiver.SSN;
            FirstName = caregiver.FirstName;
            LastName = caregiver.LastName;
            HomeAddress = caregiver.HomeAddress;
            PhoneNumber = caregiver.PhoneNumber;
            EmailAddress = caregiver.EmailAddress;
        }
        public CaregiverDTO()
        {

        }

        

    }
}
