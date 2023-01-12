using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulbasaurAPI.Repository
{
    public interface IGroupRepository
    {

        Task<Group> GetGroupByIdAsync(int id);

        Task<IEnumerable<Group>> GetAllGroupsAsync();   

        Task<Group> CreateGroupAsync();

        Task<bool> DeleteGroupAsync(int id);   

        Task UpdateGroupAsync(Group group);

        Task<bool> SaveAsync();

    }
}
