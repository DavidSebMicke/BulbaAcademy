using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;

namespace BulbasaurAPI.Repository
{
    public class CaregiverRepository : ICaregiverRepository
    {


        private readonly DbServerContext _context;

        public CaregiverRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Caregiver caregiver)
        {
            await _context.Caregivers.AddAsync(caregiver);
            return await SaveAsync();
        }
        public async Task<bool> Update()
        {
            return await SaveAsync();
        }

        public Task<bool> Delete(Caregiver entity)
        {
           var caregiverDelete = _context.Caregivers.Where(x => x.Id == entity.Id).FirstOrDefault();
           _context.Caregivers.Remove(caregiverDelete);

            return SaveAsync();
        }

        public IEnumerable<Caregiver> GetAll()
        {
            return _context.Caregivers.ToList();
        }


        public async Task<Caregiver> GetById(int id)
        {
            return await _context.Caregivers.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public Caregiver EntityExists(int id)
        {
            return _context.Caregivers.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}