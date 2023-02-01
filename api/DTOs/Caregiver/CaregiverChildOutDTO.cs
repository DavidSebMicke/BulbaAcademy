using BulbasaurAPI.DTOs.Child;

namespace BulbasaurAPI.DTOs.Caregiver
{
    public class CaregiverChildOutDTO
    {
        public List<CaregiverOutDTO> Caregivers { get; set; }
        public ChildOutDTO Child { get; set; }
        public CaregiverChildOutDTO(List<Models.Caregiver> caregiver, Models.Child child)
        {
            Caregivers = new();
            Child = new ChildOutDTO(child);



            caregiver.ForEach(c =>
            {
                Caregivers.Add(new CaregiverOutDTO(c));
            });
        }


    }
}
