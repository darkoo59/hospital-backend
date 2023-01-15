using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IConsiliumService
    {
        public void Create(Consilium consilium);
        public void CreateConsiliumWithDoctors(Consilium consilium, List<int> DoctorIds);
        public void CreateConsiliumWithSpecializations(Consilium consilium, List<int> SpecializationIds);

        IEnumerable<Consilium> GetAllConsiliumsOfDoctor(int id);

        IEnumerable<Consilium> GetAll();
    }
}
