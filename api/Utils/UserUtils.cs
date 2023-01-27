using BulbasaurAPI.DTOs.UserDTOs;
using BulbasaurAPI.Helpers;
using BulbasaurAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbasaurAPI.Utils
{
    internal static class UserUtils
    {
        public static async Task<User?> RegisterUser(string email, DbServerContext _context)
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
                    Password = Hasher.HashWithSalt(RandomPassword.GenerateRandomPassword(), out string salt),
                    Salt = salt,
                    AccessLevel = Authorization.UserAccessLevel.USER
                };


                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return newUser;
            }


        }


        public static async Task<User?> RegisterUserWithPerson(Person person, DbServerContext _context)
        {

            //checks if user already exists
            if (await _context.Users.AnyAsync(u => u.Username == person.EmailAddress))
            {

                return null;
            }
            else
            {
                User newUser = new User()
                {
                    Username = person.EmailAddress,
                    Password = Hasher.HashWithSalt(RandomPassword.GenerateRandomPassword(), out string salt),
                    Salt = salt,
                    AccessLevel = Authorization.UserAccessLevel.USER,
                    Person = person
                };


                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return newUser;
            }


        }

    }
}
