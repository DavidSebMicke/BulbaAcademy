using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository
{
    public interface ICaregiverRepository
    {
        Task<List<Caregiver>> GetAllCaregiversAsync();

        Task<Caregiver> GetCaregiverByIdAsync(int id);
       
        

        Task<bool> Save();

        Task<Caregiver> CreateCaregiverAsync(Caregiver caregiver);

      
    }
}
