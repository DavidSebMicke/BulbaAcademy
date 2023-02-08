using BulbasaurAPI.DTOs.Group;
using BulbasaurAPI.DTOs.Person;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public List<Person> People { get; set; } = new List<Person>();

        public Group()
        {

        }
        public Group(GroupDTO gDTO)
        {
            Name = gDTO.Name;   

        }
    }
}