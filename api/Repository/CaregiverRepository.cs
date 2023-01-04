using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<bool> CreateCaregiver(Caregiver caregiver)
        {
           var create = await _context.Caregivers.AddAsync(caregiver);
            
            return await Save();
            

        }

        public async Task<Caregiver> CreateCaregiverAsync(Caregiver caregiver)
        {
            _context.Caregivers.Add(caregiver);
            await _context.SaveChangesAsync();
            return caregiver;
        }

        public async Task<List<Caregiver>> GetAllCaregiversAsync()
        {
            return await _context.Caregivers.ToListAsync();
        }

        public async Task<Caregiver> GetCaregiverByIdAsync(int id)
        {
            try
            {
                return await _context.Caregivers.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

     

      

        public async Task<bool> Save()
        {
           var saved= await _context.SaveChangesAsync();
            return saved > 0? true: false;
        }
    }
}