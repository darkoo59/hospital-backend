using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public class ExaminationReportRepository : IExaminationReportRepository
    {
        private readonly HospitalDbContext _context;

        public ExaminationReportRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(ExaminationReport examinationReport)
        {
            _context.ExaminationReports.Add(examinationReport);
            _context.SaveChanges();
        }

        public void Delete(ExaminationReport examinationReport)
        {
            _context.ExaminationReports.Remove(examinationReport);
            _context.SaveChanges();
        }

        public IEnumerable<ExaminationReport> GetAll()
        {
            return _context.ExaminationReports.Include(r => r.Symptoms).Include(r => r.Recipes).ThenInclude(y => y.Medicines).ToList();
        }

        public ExaminationReport GetById(int id)
        {
            return _context.ExaminationReports.Find(id);
        }

        public void Update(ExaminationReport examinationReport)
        {
            _context.Entry(examinationReport).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
