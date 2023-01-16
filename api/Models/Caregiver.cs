namespace BulbasaurAPI.Models
{
    public class Caregiver : Person
    {
        public List<Child>? Children { get; set; } = new List<Child>();
    }
}
