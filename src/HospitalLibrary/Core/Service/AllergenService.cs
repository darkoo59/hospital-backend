using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AllergenService : IAllergenService
    {
        private readonly IAllergenRepository _allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }

        public IEnumerable<Allergen> GetAll()
        {
            return _allergenRepository.GetAll();
        }

        public Allergen GetById(int id)
        {
            return _allergenRepository.GetById(id);
        }
    }
}
