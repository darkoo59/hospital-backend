using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class DoctorService : IDoctorService
    {
        
        private readonly DoctorRepository _doctorRepository;

        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }
    }
}
