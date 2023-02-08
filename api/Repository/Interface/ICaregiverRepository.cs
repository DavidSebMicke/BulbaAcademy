using BulbasaurAPI.DTOs.Caregiver;
using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface ICaregiverRepository : IBaseRepository<Caregiver>
    {
        Task ConnectCaregiverAndChild(Caregiver caregiver, Child child);

        Task ConnectCaregiverToRoleId(Caregiver caregiver);

        bool CaregiverExists(List<CaregiverDTO> caregiver);

        Task SaveChanges();



    }
}