using BulbasaurAPI.DTOs.Caregiver;
using BulbasaurAPI.DTOs.Child;
using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IChildrenRepository : IBaseRepository<Child>
    {
        Task ConnectChildToRole(Child child);

        Task<bool> ChildExists(ChildDTO child);
    }
}
