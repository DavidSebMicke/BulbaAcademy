using BulbasaurAPI.Models;

namespace BulbasaurAPI.Repository
{
    public class CaregiverRepository : ICaregiverRepository
    {


        private readonly DbServerContext _context;

        public CaregiverRepository(DbServerContext context)
        {
            _context = context;
        }

        public bool CreateCaregiver(int childId, Caregiver caregiver)
        {
            var ChildEntity = _context.Children.Where(a => a.Id == childId).FirstOrDefault();



            //var caregiverChild = new CaregiverChild()
            //{
            //    Caregiver = caregiver,
            //    Child = ChildEntity,
            //};

            //_context.Add(caregiverChild);
            //_context.Add(caregiver);

            return Save();

        }


        public ICollection<Caregiver> GetAllCaregivers()
        {
            return _context.Caregivers.ToList();
        }

        public Caregiver GetCaregiverById(int id)
        {

            return _context.Caregivers.FirstOrDefault(x => x.Id == id);
        }





        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


    }
}