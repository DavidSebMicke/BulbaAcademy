using BulbasaurAPI.DTOs.Person;

namespace BulbasaurAPI.DTOs.Group
{
    public class GroupDTO
    {
        public string Name { get; set; }

        public List<PersonDTO> People { get; set; } = new();

        public GroupDTO(Models.Group group)
        {
            Name = group.Name;
            People = new List<PersonDTO>();

        }
    }
}
