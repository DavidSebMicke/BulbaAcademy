using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IDocumentRepository : IBaseRepository<Document>
    {
        Task<List<User>> GetUsersById(List<int> id);

        Task<List<Group>> GetGroupsById(List<int> id);
    }
}