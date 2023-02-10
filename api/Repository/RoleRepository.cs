using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class RoleRepository : IBaseRepository<Role>
    {
        private readonly DbServerContext _context;

        public RoleRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Role> Create(Role entity)
        {
            var newRole = (await _context.Roles.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return newRole;
        }

        public async Task<Role> Update(Role newEntity)
        {
            var entity = _context.Roles.Update(newEntity).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Role entity)
        {
            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<bool> EntityExists(int id)
        {
            return await _context.Roles.AnyAsync(r => r.Id == id);
        }
    }
}