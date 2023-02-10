using BulbasaurAPI.Database;
using BulbasaurAPI.DTOs.Group;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DbServerContext _context;

        public GroupRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Group> Create(Group group)
        {
            var newGroup = (await _context.Groups.AddAsync(group)).Entity;
           
            await _context.SaveChangesAsync();
            return newGroup;

        }

        public Task Delete(Group entity)
        {
            throw new NotImplementedException();
        }

     
        public Task<IEnumerable<Group>> GetGroupsByPersonId(int id)
        {
            throw new NotImplementedException();
        }

        

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public Task<Group?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        
        public Task<Group> Update(Group newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EntityExists(int id)
        {
            return await _context.Groups.AnyAsync(c => c.Id == id);
        }
    }
}