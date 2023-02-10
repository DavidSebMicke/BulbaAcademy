using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using BulbasaurAPI.Repository.Interface;
using BulbasaurAPI.Services;
using BulbasaurAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbServerContext _context;

        public UserRepository(DbServerContext context)
        {
            _context = context;
        }

        public void CombineUserAndPerson(Person person, User user)
        {
            user.Person = person;
        }

        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EntityExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUserWithPerson(Person person, string password, bool sendEmail = false)
        {
            if (await _context.Users.AnyAsync(u => u.Username == person.EmailAddress))
            {
                return null;
            }
            else
            {
                User newUser = new User()
                {
                    Username = person.EmailAddress,
                    Password = Hasher.HashWithSalt(password, out string salt),
                    Salt = salt,
                    AccessLevel = Authorization.UserAccessLevel.USER,
                };

                var newUserEntity = (await _context.Users.AddAsync(newUser)).Entity;
                CombineUserAndPerson(person, newUserEntity);
                await _context.SaveChangesAsync();
                if (sendEmail) await EmailAPI.SendPasswordToUserEmail(newUser.Username, password);
                return newUserEntity;
            }
        }

        public Task<User> Update(User newEntity)
        {
            throw new NotImplementedException();
        }
    }
}