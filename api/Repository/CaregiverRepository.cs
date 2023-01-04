using BulbasaurAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class CaregiverRepository : ICaregiverRepository
    {
        private readonly DbServerContext _context;

        public CaregiverRepository(DbServerContext context)
        {
            _context = context;
        }

        public ICollection<Caregiver> GetAllCaregivers()
        {
            using (var context = _context)
            {
                var all = context.Caregivers.ToList();
                return all;
            }
        }

        public Caregiver GetCaregiverById()
        {
            throw new NotImplementedException();
        }

        public Caregiver GetCaregiverForChild()
        {
            throw new NotImplementedException();
        }
    }
}