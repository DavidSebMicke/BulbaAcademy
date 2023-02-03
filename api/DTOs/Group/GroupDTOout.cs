namespace BulbasaurAPI.DTOs.Group
{
    public class GroupDTOout
    {
        public int Id { get; set; }

        public GroupDTOout()
        {

        }
        public GroupDTOout(Models.Group group)
        {
            Id = group.Id;
        }
    }
}
