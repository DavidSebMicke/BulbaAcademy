using BulbasaurAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BulbasaurAPI.Repository
{
    public class GroupRepository : IGroupRepository
    {

        private readonly DbServerContext _context;

        public GroupRepository(DbServerContext context)
        {
            _context = context;
        }

        public Task<Group> CreateGroupAsync()
        {
            //var groups = _context.Groups.ToListAsync();
            //return groups;
            throw new NotImplementedException();

        }

        
        public async Task<bool> DeleteGroupAsync(int id)
        {
           var delete = await _context.Groups.Where(x=> x.Id == id).FirstOrDefaultAsync();
             _context.Remove(delete);
            return await SaveAsync();
           
           
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.Where(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<bool> SaveAsync()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0 ? true : false;
        }

        public Task UpdateGroupAsync(Group group)
        {
            throw new NotImplementedException();
        }


    }
}
