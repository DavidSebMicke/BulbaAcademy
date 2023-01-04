namespace BulbasaurAPI.Models
{
    public class Caregiver : Person
    {
        public ICollection<CaregiverChild>? CaregiverChildren { get; set; }
        



    }
}
