using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository
{
    public interface ICaregiverRepository
    {
        ICollection<Caregiver> GetAllCaregivers();

        Caregiver GetCaregiverForChild();

        Caregiver GetCaregiverById();

       
    }
}
