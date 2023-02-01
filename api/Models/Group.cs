using BulbasaurAPI.DTOs.Person;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public List<Group> People { get; set; } = new();
    }
}