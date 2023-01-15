using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class ExaminationReportMapper : IGenericMapper<ExaminationReport, ExaminationReportDTO>
    {
        private readonly IGenericMapper<Symptom, SymptomDTO> _symptomMapper;
        private readonly IGenericMapper<Recipe, RecipeDTO> _recipeMapper;

        public ExaminationReportMapper(IGenericMapper<Symptom, SymptomDTO> symptomMapper, IGenericMapper<Recipe, RecipeDTO> recipeMapper)
        {
            _symptomMapper = symptomMapper;
            _recipeMapper = recipeMapper;

        }

        public ExaminationReportDTO ToDTO(ExaminationReport examinationReport)
        {
            ExaminationReportDTO examinationReportDTO = new ExaminationReportDTO();
            examinationReportDTO.ExaminationReportId = examinationReport.Id;
            examinationReportDTO.SymptomIds = examinationReport.SymptomIds;
            examinationReportDTO.Symptoms = _symptomMapper.ToDTO(examinationReport.Symptoms);
            examinationReportDTO.Report = examinationReport.Report;
            examinationReportDTO.Recipes = _recipeMapper.ToDTO(examinationReport.Recipes);
            examinationReportDTO.AppointmentId = examinationReport.AppointmentId;

            return examinationReportDTO;
        }

        public List<ExaminationReportDTO> ToDTO(List<ExaminationReport> examinationReports)
        {
            List<ExaminationReportDTO> examinationReportDTOs = new List<ExaminationReportDTO>();
            foreach (var examinationReport in examinationReports)
            {
                ExaminationReportDTO examinationReportDTO = new ExaminationReportDTO();
                examinationReportDTO.ExaminationReportId = examinationReport.Id;
                examinationReportDTO.SymptomIds = examinationReport.SymptomIds;
                examinationReportDTO.Symptoms = _symptomMapper.ToDTO(examinationReport.Symptoms);
                examinationReportDTO.Report = examinationReport.Report;
                examinationReportDTO.Recipes = _recipeMapper.ToDTO(examinationReport.Recipes);
                examinationReportDTO.AppointmentId = examinationReport.AppointmentId;
                examinationReportDTOs.Add(examinationReportDTO);
            }

            return examinationReportDTOs;
        }

        public ExaminationReport ToModel(ExaminationReportDTO examinationReportDTO)
        {
            //ExaminationReport examinationReport = new ExaminationReport();
            //examinationReport.ExaminationReportId = examinationReportDTO.ExaminationReportId;
            //examinationReport.SymptomIds = examinationReportDTO.SymptomIds;
            //examinationReport.Symptoms = _symptomMapper.ToModel(examinationReportDTO.Symptoms);
            //examinationReport.Report = examinationReportDTO.Report;
            //examinationReport.Recipes = _recipeMapper.ToModel(examinationReportDTO.Recipes);
            //examinationReport.AppointmentId = examinationReportDTO.AppointmentId;
            return new ExaminationReport(examinationReportDTO.SymptomIds, _symptomMapper.ToModel(examinationReportDTO.Symptoms), examinationReportDTO.Report, _recipeMapper.ToModel(examinationReportDTO.Recipes), examinationReportDTO.AppointmentId);

            //return examinationReport;
        }

        public List<ExaminationReport> ToModel(List<ExaminationReportDTO> examinationReportDTOs)
        {
            List<ExaminationReport> examinationReports = new List<ExaminationReport>();
            foreach (var examinationReportDTO in examinationReportDTOs)
            {
                //ExaminationReport examinationReport = new ExaminationReport();
                //examinationReport.ExaminationReportId = examinationReportDTO.ExaminationReportId;
                //examinationReport.SymptomIds = examinationReportDTO.SymptomIds;
                //examinationReport.Symptoms = _symptomMapper.ToModel(examinationReportDTO.Symptoms);
                //examinationReport.Report = examinationReportDTO.Report;
                //examinationReport.Recipes = _recipeMapper.ToModel(examinationReportDTO.Recipes);
                //examinationReport.AppointmentId = examinationReportDTO.AppointmentId;
                examinationReports.Add(new ExaminationReport(examinationReportDTO.SymptomIds, _symptomMapper.ToModel(examinationReportDTO.Symptoms), examinationReportDTO.Report, _recipeMapper.ToModel(examinationReportDTO.Recipes), examinationReportDTO.AppointmentId));
            }

            return examinationReports;
        }
    }
}
