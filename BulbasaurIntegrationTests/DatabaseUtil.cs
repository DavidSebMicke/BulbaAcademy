using Bogus;
using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbasaurIntegrationTests
{
    public static class DatabaseUtil
    {
        public static void SeedData(DbServerContext context)
        {
            var roles = new List<Role>();
            roles.Add(new Role() { Id = 1, Name = "Caregiver" });
            roles.Add(new Role() { Id = 2, Name = "Child" });
            roles.Add(new Role() { Id = 3, Name = "Teacher" });

            // Addresses
            var addressId = 1;
            var fakeAddresses = new Faker<Address>()
                //.RuleFor(o => o.Id, f => addressId++)
                .RuleFor(o => o.StreetAddress, f => f.Address.StreetAddress())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.PostalCode, f => f.Random.Number(10000, 99999));

            // Caregivers
            var personId = 1;
            var fakeCaregivers = new Faker<Caregiver>()
                //.RuleFor(o => o.Id, f => personId++)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.EmailAddress, f => f.Internet.Email())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(o => o.SSN, f => f.Random.Long(19701060000, 202012319999).ToString());

            // Children
            var fakeChildren = new Faker<Child>()
                //.RuleFor(o => o.Id, f => personId++)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(o => o.EmailAddress, f => f.Internet.Email())
                .RuleFor(o => o.SSN, f => f.Random.Long(19701060000, 202012319999).ToString());

            // Teachers
            //var personId = 0;
            //var fakeTeachers = new Faker<BulbasaurAPI.Models.Person>()
            //    .RuleFor(o => o.Id, f => personId++)
            //    .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            //    .RuleFor(o => o.LastName, f => f.Name.LastName())
            //    .RuleFor(o => o.EmailAddress, f => f.Internet.Email())
            //    .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumberFormat())
            //    .RuleFor(o => o.SSN, f => f.Random.Long(19701060000, 202012319999).ToString());

            // Gets amount to generate. Address is always 2x as teachers get their own addresses
            var genAmount = Constants.PeopleToGenerate;
            var addresses = fakeAddresses.Generate(genAmount);
            var caregivers = fakeCaregivers.Generate(genAmount);
            var children = fakeChildren.Generate(genAmount);
            //var teachers = fakeTeachers.Generate(genAmount);
            var count = 0;

            caregivers.ForEach(c =>
            {
                c.HomeAddress = addresses[count];
                c.Children = new()
                {
                    children[count]
                };
                count++;
            });

            count = 0;
            children.ForEach(c =>
            {
                c.HomeAddress = addresses[count];
                c.Caregivers = new()
                {
                    caregivers[count]
                };
                count++;
            });

            //teachers.ForEach(t => t.HomeAddress = addresses[t.Id + genAmount]);

            context.Addresses.AddRange(addresses);
            context.Caregivers.AddRange(caregivers);
            context.Children.AddRange(children);
            //await context.Persons.AddRangeAsync(teachers);

            context.SaveChanges();
        }
    }
}