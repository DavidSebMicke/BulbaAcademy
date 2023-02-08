using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IChildrenRepository : IBaseRepository<Child>
    {
        Task ConnectChildToRole(Child child);
    }
}
