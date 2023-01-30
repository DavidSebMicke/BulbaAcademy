using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulbasaurAPI.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [MaxLength(12)]
        public int SSN { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public Address HomeAddress { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public Role? Role { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}