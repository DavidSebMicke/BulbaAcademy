using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersons();

        Task<Person> GetPersonById(int id);



    }
}
