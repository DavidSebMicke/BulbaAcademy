using BulbasaurAPI.DTOs.Caregiver;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Child
{
    public class ChildDTO
    {


        [Required]
        [MinLength(12)]
        [MaxLength(12)]
        public string? SSN { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
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
