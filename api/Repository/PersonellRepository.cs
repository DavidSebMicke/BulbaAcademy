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

        public async Task<Personell> Create(Personell personell)
        {
            var newEntity = (await _context.Personells.AddAsync(personell)).Entity;
            await _context.SaveChangesAsync();
            return newEntity;
        }

        public async Task Delete(Personell personell)
        {
            _context.Personells.Remove(personell);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Personell>> GetAll()
        {
            return await _context.Personells.ToListAsync();
        }

        public async Task<Personell> Update(Personell newEntity)
        {
            var updatedEntity = _context.Personells.Update(newEntity).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task<Personell?> GetById(int id)
        {
            return await _context.Personells.FindAsync(id);
        }

        public async Task<bool> EntityExists(int id)
        {
            return _context.Personells.Any(p => p.Id == id);
        }
    }
}