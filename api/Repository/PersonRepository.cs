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

        public async Task<List<Person>> GetAllPersons()
        {

           return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}