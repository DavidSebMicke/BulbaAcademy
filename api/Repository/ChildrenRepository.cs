using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class ChildrenRepository : IChildrenRepository
    {
        private readonly DbServerContext _context;

        public ChildrenRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Child> Create(Child child)
        {
            var newChild = (await _context.Children.AddAsync(child)).Entity;
            await _context.SaveChangesAsync();
            return newChild;
        }

        public async Task<Child> Update(Child child)
        {
            var updatedEntity = _context.Children.Update(child).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task Delete(Child entity)
        {
            var childDelete = _context.Children.Where(x => x.Id == entity.Id).FirstOrDefault();
            _context.Children.Remove(childDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Child>> GetAll()
        {
            return await _context.Children.ToListAsync();
        }

        public async Task<Child?> GetById(int id)
        {
            return await _context.Children.FindAsync(id);
        }
        public async Task<bool> EntityExists(int id)
        {
            return await _context.Children.AnyAsync(c => c.Id == id);
        }

    }
}
