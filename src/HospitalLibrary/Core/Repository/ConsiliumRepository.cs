using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.Core.Repository
{
    namespace HospitalLibrary.Core.Repository
    {
        public class ConsiliumRepository : IConsiliumRepository
        {
            private readonly HospitalDbContext _context;

            public ConsiliumRepository(HospitalDbContext context)
            {
                _context = context;
            }

            public void Create(Consilium consilium)
            {
                _context.Consiliums.Add(consilium);
                _context.SaveChanges();
            }
        }
    }
}
