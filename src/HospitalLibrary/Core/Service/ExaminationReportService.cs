using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationReportService : IExaminationReportService
    {
        private readonly IExaminationReportRepository _examinationReportRepository;

        public ExaminationReportService(IExaminationReportRepository examinationReportRepository)
        {
            _examinationReportRepository = examinationReportRepository;
        }

        public void Create(ExaminationReport examinationReport)
        {
            _examinationReportRepository.Create(examinationReport); 
        }

        public void Delete(ExaminationReport examinationReport)
        {
            _examinationReportRepository.Delete(examinationReport);
        }

        public IEnumerable<ExaminationReport> GetAll()
        {
            return _examinationReportRepository.GetAll();
        }

        public ExaminationReport GetById(int id)
        {
            return _examinationReportRepository.GetById(id);
        }

        public void Update(ExaminationReport examinationReport)
        {
            _examinationReportRepository.Update(examinationReport);
        }
    }
}
