using System.Runtime.InteropServices;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;
using BulbasaurAPI.Utils;
using BulbasaurAPI.Services;
using Microsoft.AspNet.Identity;
using BulbasaurAPI.Database;

namespace BulbasaurAPI.Repository
{
    public class CaregiverRepository : ICaregiverRepository
    {
        private readonly DbServerContext _context;

        public CaregiverRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Caregiver> Create(Caregiver caregiver)
        {
            var newCaregiver = (await _context.Caregivers.AddAsync(caregiver)).Entity;
            return newCaregiver;
        }

        public async Task<Caregiver> Update(Caregiver caregiver)
        {
            var updatedEntity = _context.Caregivers.Update(caregiver).Entity;
            return updatedEntity;
        }

        public async Task Delete(Caregiver entity)
        {
            var caregiverDelete = _context.Caregivers.Where(x => x.Id == entity.Id).FirstOrDefault();
            _context.Caregivers.Remove(caregiverDelete);
        }

        public async Task<IEnumerable<Caregiver>> GetAll()
        {
            return await _context.Caregivers.ToListAsync();
        }

        public async Task<Caregiver?> GetById(int id)
        {
            return await _context.Caregivers.Include(c => c.HomeAddress).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> EntityExists(int id)
        {
            return await _context.Caregivers.AnyAsync(c => c.Id == id);
        }

        public async Task ConnectCaregiverAndChild(Caregiver caregiver, Child child)
        {
            caregiver.Children.Add(child);
            child.Caregivers.Add(caregiver);
            await ConnectCaregiverToRoleId(caregiver);
            await _context.SaveChangesAsync();
        }

        public async Task ConnectCaregiverToRoleId(Caregiver caregiver)
        {
            caregiver.Role = await _context.Roles.Where(x => x.Name == "Caregiver").FirstOrDefaultAsync();
        }

        public async Task<User?> RegisterUserWithPerson(Caregiver caregiver)
        {
            return await UserUtils.RegisterUserWithPerson(caregiver, RandomPassword.GenerateRandomPassword(), _context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}