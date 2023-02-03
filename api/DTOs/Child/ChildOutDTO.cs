using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Child
{
    public class ChildOutDTO
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public Role? Role { get; set; }
        public ChildOutDTO()
        {

        }
        public ChildOutDTO(Models.Child child)
        {
            Id = child.Id;
            FirstName = child.FirstName;
            LastName = child.LastName;
           
        }
    }
}
