namespace BulbasaurAPI.Models
{
    public class GroupPerson
    {
        public int GroupId { get; set; }

        public int PersonId { get; set; }

        public Group Group { get; set; }

        public Person Person { get; set; }

    }
}
