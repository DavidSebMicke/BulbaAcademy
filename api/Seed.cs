using BulbasaurAPI.Models;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using System.Web.Http.Controllers;

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
                        HomeAddress = "Larsgatan 1",
                        PhoneNumber = 070234412,
                        EmailAddress = "Pappasemial@gmail.com",
                        SSN = 20180204,
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating empty Group
                        Groups = new List<Models.Group>(),
                        
                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                           new Caregiver() { FirstName = "Mike", LastName = "Gullmarsson", HomeAddress = "Larsgatan 1", PhoneNumber = 070234412, EmailAddress = "Pappasemial@gmail.com", SSN = 840910,
                                            Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                .FirstOrDefault()
                                           ,}
                        }
                    },
                    new Child()
                    {
                        FirstName = "Musse",
                        LastName = "Anka",
                        HomeAddress = "Ankeborg 19",
                        PhoneNumber = 07312314,
                        EmailAddress = "Kalleanka@gmail.com",
                        SSN = 21104204,
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                               new Caregiver() { FirstName = "Kalle", LastName = "Anka", HomeAddress = "Ankeborg 19", PhoneNumber = 07312314, EmailAddress = "Mimmianka@gmail.com", SSN = 790711,
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },
                            
                               new Caregiver() { FirstName = "Mimmi", LastName = "Anka", HomeAddress = "Ankeborg 19", PhoneNumber = 07321311, EmailAddress = "Kalleanka@gmail.com", SSN = 780811,
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },
                        }  
                    },

                    new Child()
                    {
                        FirstName = "Albin",
                        LastName = "He",
                        HomeAddress = "Manillagatan 2",
                        PhoneNumber = 07344551,
                        EmailAddress = "Filipperna@gmail.com",
                        SSN = 21114204,
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                               new Caregiver() { FirstName = "Tsing", LastName = "He", HomeAddress = "Manillagatan 2", PhoneNumber = 07344551, EmailAddress = "Filipperna@gmail.com", SSN = 770711,
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },

                               new Caregiver() { FirstName = "Jao", LastName = "He", HomeAddress = "Manillagatan 2", PhoneNumber = 07388111, EmailAddress = "Jao@gmail.com", SSN = 810911,
                                                Role = _context.Roles.Where(x => x.Name == "Caregiver")
                                                    .FirstOrDefault()
                                               },
                        }
                    },
                    new Child()
                    {
                        FirstName = "Stefan",
                        LastName = "Mormorsson",
                        HomeAddress = "Mormorsgatan 19",
                        PhoneNumber = 07318315,
                        EmailAddress = "mormors@gmail.com",
                        SSN = 21106209,
                        Role = _context.Roles.Where(x => x.Name == "Child").FirstOrDefault(),

                        // Creating and Assigning the Childs Caregivers
                        Caregivers = new List<Caregiver>()
                        {
                               new Caregiver() { FirstName = "Mormor", LastName = "Mormorsson", HomeAddress = "Mormorsgatan 19", PhoneNumber = 07318315, EmailAddress = "Mormors@gmail.com", SSN = 590811,
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
                        HomeAddress = "Fågelgatan 21", 
                        PhoneNumber = 07319915, 
                        EmailAddress = "Teppas@gmail.com", 
                        SSN = 840811,                
                        Role = _context.Roles.Where(x => x.Name == "Caregiver").FirstOrDefault(),
                        Children = new List<Child>()
                        {
                            new Child() { FirstName = "Magnus", LastName = "Fågelberg", HomeAddress = "Fågelgatan 21", PhoneNumber = 07319915, EmailAddress = "Teppas@gmail.com", SSN = 210111,
                                                Role = _context.Roles.Where(x => x.Name == "Child")
                                                    .FirstOrDefault()
                                               },
                            new Child() { FirstName = "Monika", LastName = "Fågelberg", HomeAddress = "Fågelgatan 21", PhoneNumber = 07319915, EmailAddress = "Teppas@gmail.com", SSN = 211211,
                                                Role = _context.Roles.Where(x => x.Name == "Child")
                                                    .FirstOrDefault()
                                               },
                        }
                    },
                };
                _context.Caregivers.AddRange(careGivers);

                // Adding Personell 
                var personells = new List<Personell>()
                {
                    new Personell()
                    {
                        FirstName = "Stefan",
                        LastName = "Hemlersson",
                        SSN = 640911,
                        PhoneNumber = 010229910,
                        EmailAddress = "Semlan@gmail.com",
                        HomeAddress = "Knapegatan 11",
                        Employment = "Teacher",
                        FullTimeEmployment = true,
                        Role = _context.Roles.Where(x => x.Name == "Teacher")
                                                .FirstOrDefault()
                    },
                    new Personell()
                    {
                        FirstName = "Ninni",
                        LastName = "Nejmlar",
                        SSN = 820918,
                        PhoneNumber = 070289911,
                        EmailAddress = "Kuss@gmail.com",
                        HomeAddress = "Nystangatan 71",
                        Employment = "Teacher",
                        FullTimeEmployment = true,
                        Role = _context.Roles.Where(x => x.Name == "Teacher")
                                                .FirstOrDefault()
                    },
                    new Personell()
                    {
                        FirstName = "Tunika",
                        LastName = "Tunnlarsson",
                        SSN = 690911,
                        PhoneNumber = 073220010,
                        EmailAddress = "Tunnan@gmail.com",
                        HomeAddress = "Medeltidaklädersgatan 211",
                        Employment = "Teacher",
                        FullTimeEmployment = false,
                        Role = _context.Roles.Where(x => x.Name == "Teacher")
                                                .FirstOrDefault()
                    },
                    new Personell()
                    {
                        FirstName = "Marius",
                        LastName = "Munhåla",
                        SSN = 720918,
                        PhoneNumber = 07077110,
                        EmailAddress = "Rektor@gmail.com",
                        HomeAddress = "Mestrogatan 14",
                        Employment = "Headmaster",
                        FullTimeEmployment = true,
                        Role = _context.Roles.Where(x => x.Name == "Headmaster")
                                                .FirstOrDefault()

                    }
                };
                _context.Personells.AddRange(personells);
                _context.SaveChanges();

                // Creating Group and Assigning Children to it
                var newClassGroup = new Models.Group() { Name = "Klass 5A" };
                _context.Groups.Add(newClassGroup);
                var childList = children.Where(x => x.SSN.ToString().StartsWith("21")); 
                foreach (var c in childList)
                {
                    c.Groups.Add(newClassGroup);
                }

                // Assigning Teacher to specific Group
                var teacher = personells.Where(x => x.Role?.Name == "Teacher").FirstOrDefault();
                teacher?.Groups.Add(newClassGroup);

                // Creating Group and Assigning Parents to it
                var supportGroup = new Models.Group() { Name = "Support Grupp Löss Utbrott" };
                _context.Groups.Add(supportGroup);
                var careGiverList = _context.Caregivers.Where(x => x.LastName == "Anka" || x.LastName == "Mormorsson" || x.LastName == "Fågelberg").ToList();
                
                
                foreach (var c in careGiverList)
                {
                    c.Groups.Add(supportGroup);
                }

                // Creating Group and Assigning Personell to it
                var teacherGroup = new Models.Group() { Name = "Teachers Lounge" };
                _context.Groups.Add(teacherGroup);
                foreach (var p in personells)
                {
                    p.Groups.Add(teacherGroup);
                }
            }
            
            _context.SaveChanges();
        }
    }
}
        
        

