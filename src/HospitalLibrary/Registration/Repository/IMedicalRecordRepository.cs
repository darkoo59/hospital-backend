using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Repository
{
    public interface IMedicalRecordRepository
    {
        void Register(MedicalRecord medicalRecord);
    }
}
