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

        public Task<Group> Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EntityExists(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Group> GetGroupByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetGroupsByPersonId(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<Group> GetGroupByIdAsync(int id)
        //{
        //    return await _context.Groups.Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        public Task<IEnumerable<Group>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Group?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetGroupsByPersonId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Update(Group newEntity)
        {
            throw new NotImplementedException();
        }
    }
}