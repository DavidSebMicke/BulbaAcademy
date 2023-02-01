using BulbasaurAPI.DTOs.Child;

namespace BulbasaurAPI.DTOs.Caregiver
{
    public class CaregiverChildDTO
    {
        public List<CaregiverDTO> Caregivers { get; set; }
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
