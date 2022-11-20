using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InpatientTreatmentTherapyController : ControllerBase
    {
        private readonly IInpatientTreatmentTherapyService _inpatientTreatmentTherapyService;

        public InpatientTreatmentTherapyController(IInpatientTreatmentTherapyService inpatientTreatmentTherapyService)
        {
            _inpatientTreatmentTherapyService = inpatientTreatmentTherapyService;
        }

        

    }
}
