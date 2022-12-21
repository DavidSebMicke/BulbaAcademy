namespace BulbasaurAPI.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string HomeAddress { get; set; }

        public int PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }

        public Role Role { get; set; }


        public List<Group>? Groups { get; set; }

    }
}
