using BulbasaurAPI.DTOs.Group;
using System.ComponentModel.DataAnnotations;

namespace BulbasaurAPI.DTOs.Person
{
    public class PersonDTO
    {
      
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

      
        public string PhoneNumber { get; set; }

        
        public string EmailAddress { get; set; }

        public List<GroupDTO> Groups { get; set; } = new List<GroupDTO>();

        public PersonDTO(Models.Person person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName; 
            PhoneNumber = person.PhoneNumber;   
            EmailAddress = person.EmailAddress;
            Groups = new List<GroupDTO>();

        }

    }
}
