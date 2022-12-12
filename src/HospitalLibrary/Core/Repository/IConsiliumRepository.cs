using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IConsiliumRepository
    {
        public void Create(Consilium consilium);

        IEnumerable<Consilium> GetAll();
    }
}
