using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;

        public ConsiliumService(IConsiliumRepository consiliumRepository)
        {
            _consiliumRepository = consiliumRepository;
        }

        public void Create(Consilium consilium)
        {
            _consiliumRepository.Create(consilium);
        }
    }
}
