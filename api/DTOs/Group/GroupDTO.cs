using BulbasaurAPI.DTOs.Person;

namespace BulbasaurAPI.DTOs.Group
{
    public class GroupDTO
    {
        public string Name { get; set; }

        

        public GroupDTO(Models.Group group)
        {
            Name = group.Name;
            

        }
        public GroupDTO()
        {

        }
    }
}
