using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public List<Person> People { get; set; } = new();
    }
}