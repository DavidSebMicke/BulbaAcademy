using BulbasaurAPI.DTOs.Child;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Caregiver
{
    public class CaregiverChildDTO
    {
        [Required(ErrorMessage = "Vårdnadshavare saknas.")]
        [MinLength(1, ErrorMessage = "Vårdnadshavare saknas.")]
        public List<CaregiverDTO> Caregivers { get; set; }

        [Required(ErrorMessage = "Barninformation saknas.")]
        public ChildDTO Child { get; set; }

        public CaregiverChildDTO()
        {
        }

        //Kan man föra in detta så att vi kan få ut childDTO, CaregiverDTO
        public CaregiverChildDTO(List<Models.Caregiver> caregiver, Models.Child child)
        {
            Caregivers = new();
            Child = new ChildDTO(child);

            caregiver.ForEach(c =>
             {
                 Caregivers.Add(new CaregiverDTO(c));
             });
        }
    }
}