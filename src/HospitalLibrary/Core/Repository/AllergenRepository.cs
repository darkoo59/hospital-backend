using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class AllergenRepository : IAllergenRepository
    {
        private readonly HospitalDbContext _context;

        public AllergenRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Allergen> GetAll()
        {
            return _context.Allergens.ToList();

        }

        public Allergen GetById(int id)
        {
            return _context.Allergens.Find(id);
        }
    }
}
