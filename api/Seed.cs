using BulbasaurAPI.Database;
using BulbasaurAPI.Models;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Web.Http.Controllers;
using System.Xml.Linq;

namespace BulbasaurAPI
{
    public class Seed
    {
        private readonly DbServerContext _context;

        public Seed(DbServerContext context)
        {
            this._context = context;
        }

        public void SeedDataContext()
        {
            if (!_context.Persons.Any())
            {
                // Adding Roles
                var roles = new List<Role>()
                {
                    new Role()
                    {
                        Name = "Child"
                    },
                    new Role()
                    {
                        Name = "Caregiver"
                    },
                    new Role()
                    {
                        Name = "Teacher"
                    },
                    new Role()
                    {
                        Name = "Headmaster"
                    },
                };
                _context.AddRange(roles);
                _context.SaveChanges();

                //Adding a list of Children and Assigning Caregivers at the same time
                var children = new List<Child>()
                {
                    new Child()
                    {
                        FirstName = "Majken",
                        LastName = "Gullmarsson",
                        HomeAddress = new("Larsgatan 1", "Sollentuna", 12313),
                        PhoneNumber = "070234412",
                        EmailAddress = "Pappasemial@gmail.com",
                        SSN = "20180204312",
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating empty Group
                        Groups = new List<Models.Group>(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                           new Caregiver() { FirstName = "Mike", LastName = "Gullmarsson", HomeAddress = new("Larsgatan 1", "Sollentuna", 12313), PhoneNumber = "070234412", EmailAddress = "Pappasemial@gmail.com", SSN = "19180204312",
                                            Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                .FirstOrDefault()
                                           ,}
                        }
                    },
                    new Child()
                    {
                        FirstName = "Musse",
                        LastName = "Anka",
                        HomeAddress = new("Ankeborg 19", "Ankeborg", 66666),
                        PhoneNumber = "07312314",
                        EmailAddress = "Kalleanka@gmail.com",
                        SSN = "19280204312",
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                               new Caregiver() { FirstName = "Kalle", LastName = "Anka", HomeAddress = new("Ankeborg 19", "Ankeborg", 66666), PhoneNumber = "07312314", EmailAddress = "Mimmianka@gmail.com", SSN = "19380204312",
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },

                               new Caregiver() { FirstName = "Mimmi", LastName = "Anka", HomeAddress = new("Ankeborg 19", "Ankeborg", 66666), PhoneNumber = "07312314", EmailAddress = "Kalleanka@gmail.com", SSN = "19480204312",
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },
                        }
                    },

                    new Child()
                    {
                        FirstName = "Albin",
                        LastName = "He",
                        HomeAddress = new("Manillagatan 2", "Götlaborg", 44123),
                        PhoneNumber = "07344551",
                        EmailAddress = "Filipperna@gmail.com",
                        SSN = "12330204312",
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                               new Caregiver() { FirstName = "Tsing", LastName = "He", HomeAddress = new("Manillagatan 2", "Götlaborg", 44123), PhoneNumber = "07344551", EmailAddress = "Filipperna@gmail.com", SSN = "19680204312",
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },

                               new Caregiver() { FirstName = "Jao", LastName = "He", HomeAddress = new("Manillagatan 2", "Götlaborg", 44123), PhoneNumber = "07344551", EmailAddress = "Jao@gmail.com", SSN = "19580204312",
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },
                        }
                    },
                    new Child()
                    {
                        FirstName = "Stefan",
                        LastName = "Mormorsson",
                        HomeAddress = new("Mormorsgatan 19", "Grandma Town", 12313),
                        PhoneNumber = "07318315",
                        EmailAddress = "mormors@gmail.com",
                        SSN = "2000204312",
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                               new Caregiver() { FirstName = "Mormor", LastName = "Mormorsson", HomeAddress = new("Mormorsgatan 19", "Grandma Town", 12313), PhoneNumber = "07318315", EmailAddress = "Mormors@gmail.com", SSN = "19800204312",
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },
                        }
                    },
                };

                _context.Children.AddRange(children);

                // Creating and Adding Caregiver and two Assigned Children
                var careGivers = new List<Caregiver>()
                {
                    new Caregiver()
                    {
                        FirstName = "Teppas",
                        LastName = "Fågelberg",
                        HomeAddress = new("Fågelgatan 21", "Mölndal", 40923),
                        PhoneNumber = "07319915",
                        EmailAddress = "Teppas@gmail.com",
                        SSN = "19880204312",
                        Role = _context.Roles.Where(x => x.Name == "Caregiver").FirstOrDefault(),
                        Children = new List<Child>()
                        {
                            new Child() { FirstName = "Magnus", LastName = "Fågelberg", HomeAddress = new("Fågelgatan 21", "Mölndal", 40923), PhoneNumber = "07319915", EmailAddress = "Teppas@gmail.com", SSN = "20120204312",
                                                Role = _context.Roles.Where(x => x.Name == "Child")
                                                    .FirstOrDefault()
                                               },
                            new Child() { FirstName = "Monika", LastName = "Fågelberg", HomeAddress = new("Fågelgatan 21", "Mölndal", 40923), PhoneNumber = "07319915", EmailAddress = "Teppas@gmail.com", SSN = "20150204312",
                                                Role = _context.Roles.Where(x => x.Name == "Child")
                                                    .FirstOrDefault()
                                               },
                        }
                    },
                };
                _context.Caregivers.AddRange(careGivers);

                // Creating Group and Assigning Children to it
                var newClassGroup = new Models.Group() { Name = "Klass 5A" };
                _context.Groups.Add(newClassGroup);
                var childList = children.Where(x => x.SSN.ToString().StartsWith("21"));
                foreach (var c in childList)
                {
                    c.Groups.Add(newClassGroup);
                }
                new Models.Group() { Name = "Violen" };
                new Models.Group() { Name = "Humlan" };
                new Models.Group() { Name = "Hagen" };
                new Models.Group() { Name = "Gullvivan" };

                // Creating Group and Assigning Parents to it
                var supportGroup = new Models.Group() { Name = "SupportGrupp LössUtbrott" };
                _context.Groups.Add(supportGroup);
                var careGiverList = _context.Caregivers.Where(x => x.LastName == "Anka" || x.LastName == "Mormorsson" || x.LastName == "Fågelberg").ToList();

                foreach (var c in careGiverList)
                {
                    c.Groups.Add(supportGroup);
                }
            }

            _context.SaveChanges();
        }
    }
}