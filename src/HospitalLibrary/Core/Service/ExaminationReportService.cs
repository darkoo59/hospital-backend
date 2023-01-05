using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class ExaminationReportService : IExaminationReportService
    {
        private readonly IExaminationReportRepository _examinationReportRepository;
        private readonly IMedicineRepository _medicineRepository;

        public ExaminationReportService(IExaminationReportRepository examinationReportRepository,IMedicineRepository medicineRepository)
        {
            _examinationReportRepository = examinationReportRepository;
            _medicineRepository = medicineRepository;
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

        public bool IsAlreadyAdded(List<ExaminationReport> foundedReports, ExaminationReport examinationReport)
        {
            if(foundedReports.Count == 0)
            {
                return false;
            }
            
            foreach(ExaminationReport examination in foundedReports)
            {
                if(examination.Id == examinationReport.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<ExaminationReport> Search(String searchText)
        {
            List<ExaminationReport> reports = _examinationReportRepository.GetAll().ToList();
            List<ExaminationReport> foundedReports = new List<ExaminationReport>();
            //Pretraga po obicnim recima
            if (searchText.Contains("") && !searchText.Contains("'"))
            {
                string[] splittedSearchText = searchText.Split(' ');

                //Pretraga sadrzaja po obicnim recima
                foreach (ExaminationReport examinationReport in reports)
                {
                    foreach (String s in splittedSearchText)
                    {
                        if (examinationReport.Report.ToLower().Contains(s.ToLower()))
                        {
                            if (IsAlreadyAdded(foundedReports, examinationReport) == false)
                            {
                                foundedReports.Add(examinationReport);
                            }
                        }
                    }
                }
                //Pretraga lekova po obicnim recima
                foreach (ExaminationReport examinationReport in reports)
                {
                    foreach (String s in splittedSearchText)
                    {
                        foreach (Recipe recipe in examinationReport.Recipes)
                        {
                            foreach (Medicine medicine in recipe.Medicines)
                            {
                                if (medicine.Name.ToLower().Contains(s.ToLower()))
                                {
                                    if (IsAlreadyAdded(foundedReports, examinationReport) == false)
                                    {
                                        foundedReports.Add(examinationReport);
                                    }
                                }
                            }
                        }
                    }
                }
            }
           
            //Pretraga sadrzaja po frazama
            if (searchText.Contains("'"))
            {
                searchText = searchText.Replace("'"," ");
                string[] splittedSearchText = searchText.Split(" ");
                
                foreach (ExaminationReport examinationReport in reports)
                {
                    string[] splittedReport = examinationReport.Report.Split(' ');
                    
                    foreach(String s1 in splittedReport)
                    {
                        foreach (String s2 in splittedSearchText)
                        {
                            if (s1.Equals(s2))
                            {
                                if (IsAlreadyAdded(foundedReports, examinationReport) == false)
                                {
                                    foundedReports.Add(examinationReport);
                                }
                            }
                        }
                    }
                }

                //Pretraga lekova po frazama
                foreach (ExaminationReport examinationReport in reports)
                {
                    foreach (String s in splittedSearchText)
                    {
                        foreach (Recipe recipe in examinationReport.Recipes)
                        {
                            foreach (Medicine medicine in recipe.Medicines)
                            {
                                if (medicine.Name.Equals(s))
                                {
                                    if (IsAlreadyAdded(foundedReports, examinationReport) == false)
                                    {
                                        foundedReports.Add(examinationReport);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return foundedReports;
        }
    }
}
