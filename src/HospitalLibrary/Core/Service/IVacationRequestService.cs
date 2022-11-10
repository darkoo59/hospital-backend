﻿using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IVacationRequestService
    {
        IEnumerable<VacationRequest> GetAll();
        public VacationRequest GetById(int id);
        public bool IsVacationDateStartValid(VacationRequest vacationRequest);
    }
}
