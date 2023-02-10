using BulbasaurAPI.Authorization;
using BulbasaurAPI.DTOs.UserDTOs;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public Guid GUID { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Salt { get; set; }

        public Person? Person { get; set; }

        public UserAccessLevel AccessLevel { get; set; }

        
    }
}