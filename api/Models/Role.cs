using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class Role
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
    }
}