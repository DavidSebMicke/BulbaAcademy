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
                var roles = new List<Role>()
                {
                    new Role()
                    {
                        Name = "child"
                    },
                    new Role()
                    {
                        Name = "parent"
                    },
                    new Role()
                    {
                        Name = "teacher"
                    },
                    new Role()
                    {
                        Name = "headmaster"
                    },
                };
                _context.AddRange(roles);
                _context.SaveChanges();
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
                        Role = _context.Roles.Where(x => x.Name == "child").FirstOrDefault(),

                        Groups = new List<Models.Group>(),
                        
                        CaregiverChildren = new List<CaregiverChild>()
                        {
                            new CaregiverChild()
                            {
                                Caregiver = new Caregiver() { FirstName = "Mike", LastName = "Gullmarsson", HomeAddress = "Larsgatan 1", PhoneNumber = 070234412, EmailAddress = "Pappasemial@gmail.com", SSN = 840910 }
                            }
                        }
                    },
                    new Child()
                    {
                        FirstName = "Musse",
                        LastName = "Långbensson",
                        HomeAddress = "Ankeborg 19",
                        PhoneNumber = 07312314,
                        EmailAddress = "kalleanka@gmail.com",
                        SSN = 21104204,
                        
                        

                        CaregiverChildren = new List<CaregiverChild>()
                        {
                            new CaregiverChild()
                            {
                                Caregiver = new Caregiver() { FirstName = "Kalle", LastName = "Anka", HomeAddress = "Ankeborg 19", PhoneNumber = 07312314, EmailAddress = "mimmianka@gmail.com", SSN = 790711 }
                            },
                            new CaregiverChild()
                            {
                                Caregiver = new Caregiver() { FirstName = "Mimmi", LastName = "Anka", HomeAddress = "Ankeborg 19", PhoneNumber = 07321311, EmailAddress = "mimmianka@gmail.com", SSN = 780811}
                            }
                        }  
                    }
                    
                };
                var group = new Models.Group() { Name = "Klass 5A" };
                _context.Groups.Add(group);
                var child = children.Where(c => c.FirstName == "Musse" || c.FirstName == "Majken");
                
                foreach (var c in child)
                {
                    c.Groups.Add(group);
                }

                _context.Children.AddRange(children);
                
                var personells = new List<Personell>()
                {
                    new Personell()
                    {
                        FirstName = "Stefan",
                        LastName = "Hemlersson",
                        SSN = 640911,
                        HomeAddress = "Knapegatan 11",
                        Employment = "Teacher",
                        FullTimeEmployment = true,

                        
                    },
                    new Personell()
                    {
                        FirstName = "Marius",
                        LastName = "Munhåla",
                        SSN = 720918,
                        HomeAddress = "Mestrogatan 14",
                        Employment = "Headmaster",
                        FullTimeEmployment = true,
                        
                    }
                };
                _context.Personells.AddRange(personells);

            }
            
            _context.SaveChanges();
        }
    }
}
        
        

