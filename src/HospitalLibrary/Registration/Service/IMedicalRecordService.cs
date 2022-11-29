using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Service
{
    public interface IMedicalRecordService
    {
        Task<bool> Register(MedicalRecord medicalRecord);
        IEnumerable<MedicalRecord> GetAll();
        MedicalRecord GetById(int id);
        void Delete(MedicalRecord medicalRecord);
    }
}
