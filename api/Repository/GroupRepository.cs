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

        public async Task<Group> CreateGroupAsync(Group group)
        {
             
            //return await _context.Groups.AddAsync(group);
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

        public async Task<IEnumerable<Group>> GetGroupsByPersonId(int id)
        {
            var person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
            var result = await _context.Groups
                .Where<Group>(x => x.Persons.Contains(person))
                .Include(x => x.Persons).ThenInclude(z => z.Role)
                .ToListAsync();
            return result;
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
