using BulbasaurAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Caregiver
{
    public class CaregiverOutDTO
    {

        public int Id { get; set; }
        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        public List<string> Groups { get; set; }
        public CaregiverOutDTO()
        {

        }
        public CaregiverOutDTO(Models.Caregiver caregiver)
        {
            Id = caregiver.Id;
            FirstName = caregiver.FirstName;
            LastName = caregiver.LastName;
            Groups = (caregiver.Groups.Select(item => item.Name)).ToList();
        }
    }


}
