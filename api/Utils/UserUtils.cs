using BulbasaurAPI.Models;
using BulbasaurAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Utils
{
    internal class UserUtils
    {

        private static DbServerContext _context;

        public UserUtils(DbServerContext context)
        {
            _context = context;
        }

        public static async Task<User?> RegisterUser(string email, string password, bool sendEmail = false)
        {
            //checks if email format is valid
            if (!InputValidator.ValidateEmailFormat(email)) 
            {

                return null;
            }

            //checks if user already exists
            else if (await _context.Users.AnyAsync(u => u.Username == email))
            {

                return null;
            }
            else
            {
                User newUser = new User()
                {
                    Username = email,
                    Password = Hasher.HashWithSalt(password, out string salt),
                    Salt = salt,
                    AccessLevel = Authorization.UserAccessLevel.USER
                };


                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                await EmailAPI.SendPasswordToUserEmail(email, password);

                return newUser;
            }


        }



    }
}
