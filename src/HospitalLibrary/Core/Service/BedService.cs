using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Core.Service
{
    public class BedService : IBedService
    {

        private readonly IBedRepository _bedRepository;

        public BedService(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }
        public Task<bool> Create(Bed bed)
        {
            throw new NotImplementedException();
        }

        public void Delete(Bed bed)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bed> GetAll()
        {
            return _bedRepository.GetAll();
        }

        public Bed GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Bed bed)
        {
            _bedRepository.Update(bed);
        }

        public void SetIsNotAvailable(int bedId)
        {
            foreach (var bed in GetAll())
            {
                if (bed.BedId == bedId)
                {
                    bed.IsAvailable = false;
                    Update(bed);
                }
            }
        }
    }
}
