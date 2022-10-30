using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepository;

        public VacationService(IVacationRepository vacationRepository)
        {
            _vacationRepository = vacationRepository;
        }
        public void Create(Vacation vacation)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vacation vacation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationRepository.GetAll();
        }

        public Vacation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vacation vacation)
        {
            throw new NotImplementedException();
        }
    }
}
