namespace BulbasaurAPI.Models
{
    public class CaregiverChild
    {
        public int CaregiverId { get; set; }

        public int ChildId { get; set; }

        public Caregiver Caregiver { get; set; }

        public Child Child { get; set; }

    }
}
