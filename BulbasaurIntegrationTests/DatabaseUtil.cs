using Bogus;
using BulbasaurAPI;
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
        public static async void SeedData(DbServerContext context)
        {
            var roles = new List<Role>();
            roles.Add(new Role() { Id = 1, Name = "Caregiver" });
            roles.Add(new Role() { Id = 2, Name = "Child" });
            roles.Add(new Role() { Id = 3, Name = "Teacher" });

            // Addresses
            var addressId = 0;
            var fakeAddresses = new Faker<Address>()
                .RuleFor(o => o.Id, f => addressId++)
                .RuleFor(o => o.StreetAddress, f => f.Address.StreetAddress())
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.PostalCode, f => f.Random.Number(10000, 99999));

            // Caregivers
            var caregiverId = 0;
            var fakeCaregivers = new Faker<Caregiver>()
                .RuleFor(o => o.Id, f => caregiverId++)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.EmailAddress, f => f.Internet.Email())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(o => o.SSN, f => f.Random.Long(19701060000, 202012319999).ToString());

            // Children
            var childId = 0;
            var fakeChildren = new Faker<Child>()
                .RuleFor(o => o.Id, f => childId++)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(o => o.EmailAddress, f => f.Internet.Email())
                .RuleFor(o => o.SSN, f => f.Random.Long(19701060000, 202012319999).ToString());

            // Teachers
            var personId = 0;
            var fakeTeachers = new Faker<BulbasaurAPI.Models.Person>()
                .RuleFor(o => o.Id, f => personId++)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.EmailAddress, f => f.Internet.Email())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(o => o.SSN, f => f.Random.Long(19701060000, 202012319999).ToString());

            // Gets amount to generate. Address is always 2x as teachers get their own addresses
            var genAmount = Constants.PeopleToGenerate;
            var addresses = fakeAddresses.Generate(genAmount * 2);
            var caregivers = fakeCaregivers.Generate(genAmount);
            var children = fakeChildren.Generate(genAmount);
            var teachers = fakeTeachers.Generate(genAmount);

            caregivers.ForEach(c =>
            {
                c.HomeAddress = addresses[c.Id];
                c.Children = new()
                {
                    children[c.Id]
                };
            });
            children.ForEach(c =>
            {
                c.HomeAddress = addresses[c.Id];
                c.Caregivers = new()
                {
                    caregivers[c.Id]
                };
            });

            teachers.ForEach(t => t.HomeAddress = addresses[t.Id + genAmount]);

            await context.Addresses.AddRangeAsync(addresses);
            await context.Caregivers.AddRangeAsync(caregivers);
            await context.Children.AddRangeAsync(children);
            await context.Persons.AddRangeAsync(teachers);

            await context.SaveChangesAsync();
        }
    }
}