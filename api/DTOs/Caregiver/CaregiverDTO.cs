using BulbasaurAPI.DataAnnotations;
using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Caregiver
{
    public class CaregiverDTO
    {
        [Required(ErrorMessage = "Personnummer saknas.")]
        [MinLength(12, ErrorMessage = "Personnummer för kort. Måste bestå av 12 siffror.")]
        [MaxLength(12, ErrorMessage = "Personnummer för långt. Måste bestå av 12 siffror.")]
        [OnlyNumbers(ErrorMessage = "Personnummer får endast bestå av siffror.")]
        public string SSN { get; set; }

        [Required(ErrorMessage = "Förnamn saknas.")]
        [MaxLength(128, ErrorMessage = "Förnamn för långt.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn saknas.")]
        [MaxLength(128, ErrorMessage = "Efternamn för långt.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adressobjektet saknas.")]
        public Address HomeAddress { get; set; }

        [Required(ErrorMessage = "Telefonnummer saknas.")]
        [PhoneNumber(ErrorMessage = "Ogiltigt telefonnummer. Endast telefonnummer som börjar med + eller 0 och därefter endast innehåller siffror är tillåtna.")]
        [MaxLength(20, ErrorMessage = "Telefonnummer för långt.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Emailadress saknas.")]
        [MaxLength(255, ErrorMessage = "Emailadress för lång.")]
        [EmailAddress(ErrorMessage = "Ogiltig emailadress.")]
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