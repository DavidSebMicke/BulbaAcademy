using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>

    {
        public Task<User> RegisterUserWithPerson(Person person, string password, bool sendEmail = false);

        public void CombineUserAndPerson(Person person, User user);
    }
}
