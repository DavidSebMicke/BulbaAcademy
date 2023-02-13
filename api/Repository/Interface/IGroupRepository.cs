using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
  

        Task<IEnumerable<Group>> GetGroupsByPersonId(int id);
        Task SetGroupForPerson(Person person,List<Group> group);

        Task<Group> DeleteGroupById(int id);   

    }
}