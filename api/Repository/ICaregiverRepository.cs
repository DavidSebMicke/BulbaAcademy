using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository
{
    public interface ICaregiverRepository
    {
        ICollection<Caregiver> GetAllCaregivers();

        Caregiver GetCaregiverById(int id);
       
        

       bool Save();

        bool CreateCaregiver(int childId, Caregiver caregiver);

      
    }
}
