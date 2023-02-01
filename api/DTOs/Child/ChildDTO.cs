using BulbasaurAPI.DataAnnotations;
using BulbasaurAPI.DTOs.Caregiver;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Child
{
    public class ChildDTO
    {
        [Required(ErrorMessage = "Personnummer saknas.")]
        [MinLength(12, ErrorMessage = "Personnummer för kort. Måste bestå av 12 siffror.")]
        [MaxLength(12, ErrorMessage = "Personnummer för långt. Måste bestå av 12 siffror.")]
        [OnlyNumbers(ErrorMessage = "Endast siffror tillåtna i personnummret.")]
        public string? SSN { get; set; }

        [Required(ErrorMessage = "Förnamn saknas.")]
        [MaxLength(128, ErrorMessage = "Förnamn för långt.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn saknas.")]
        [MaxLength(128, ErrorMessage = "Efternamn för långt.")]
        public string LastName { get; set; }

        public ChildDTO(Models.Child child)
        {
            FirstName = child.FirstName;
            LastName = child.LastName;
        }

        public ChildDTO()
        {
        }
    }
}