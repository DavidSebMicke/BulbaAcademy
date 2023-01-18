using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersons();

        Task<Person> GetPersonById(int id);



    }
}
