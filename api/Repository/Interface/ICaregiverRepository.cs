using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface ICaregiverRepository : IBaseRepository<Caregiver>
    {
        Task ConnectCaregiverAndChild(Caregiver caregiver, Child child);
    }
}