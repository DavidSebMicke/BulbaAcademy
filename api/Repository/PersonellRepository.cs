using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BulbasaurAPI.Repository
{
    public class PersonellRepository : IPersonellRepository
    {
        private readonly DbServerContext _context;

        public PersonellRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Personell personell)
        {
            await _context.Personells.AddAsync(personell);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Personell personell)
        {
            var deletedPersonell = _context.Personells.Where(x => x.Id == personell.Id).FirstOrDefault();
            _context.Personells.Remove(deletedPersonell);

            return await SaveAsync();
        }

        public IEnumerable<Personell> GetAll()
        {
            return _context.Personells.ToList();
        }

        public async Task<bool> Update()
        {
            return await SaveAsync();
        }
        public async Task<Personell> GetById(int id)
        {
            return await _context.Personells.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            var savedEntity = await _context.SaveChangesAsync();
            return savedEntity > 0 ? true : false;
        }

        public Personell EntityExists(int id)
        {
            return _context.Personells.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
