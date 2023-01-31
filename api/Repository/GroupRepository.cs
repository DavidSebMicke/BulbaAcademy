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

        public async Task<GroupDTO> Create(Group entity)
        {
            var create = await _context.Groups.AddAsync(entity);
            var newDto = new GroupDTO();

            newDto.Name = entity.Name;
            newDto.People = entity.People;
        }




        public async Task Delete(Group entity)
        {
            // TODO this..
            //Denna kanske failar iom kopplingar som finns med FKs. 
            var delete = await _context.Groups.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            _context.Remove(delete);

            await _context.SaveChangesAsync();

        }

        //public async Task<Group> CreateGroupAsync(Group group)
        //{
        //    return await _context.Groups.AddAsync(group);
        //}



        public Task<bool> EntityExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        //public async Task<Group> GetGroupByIdAsync(int id)
        //{
        //    return await _context.Groups.Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task<IEnumerable<Group>> GetGroupsByPersonId(int id)
        //{
        //    var person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
        //    var user = await _context.Users.Where(u => u.Person.Id == person.Id).FirstOrDefaultAsync();

        //    var result = await _context.Groups
        //        .Where<Group>(x => x.Users.Contains(user.Person))
        //        .Include(x => x.People)
        //        .ThenInclude(p => p.Role)
        //        .ToListAsync();
        //    return result;
        //}


        public Task<Group> Update(Group newEntity)
        {
            throw new NotImplementedException();
        }


    }
}