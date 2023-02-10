using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbServerContext _context;

        public PersonRepository(DbServerContext context)
        {
            _context = context;
        }

        public async Task<Person> Create(Person person)
        {
            var newPerson = (await _context.Persons.AddAsync(person)).Entity;
            await _context.SaveChangesAsync();
            return newPerson;
        }

        public async Task<Person> Update(Person person)
        {
            var updatedEntity = _context.Persons.Update(person).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task Delete(Person entity)
        {
            var personDelete = await _context.Persons.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            _context.Persons.Remove(personDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person?> GetById(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<bool> EntityExists(int id)
        {
            return await _context.Persons.AnyAsync(c => c.Id == id);
        }

        
    }
}