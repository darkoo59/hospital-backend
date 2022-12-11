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
            examinationReportDTO.ExaminationReportId = examinationReport.ExaminationReportId;
            examinationReportDTO.Symptoms = _symptomMapper.ToDTO(examinationReport.Symptoms);
            examinationReportDTO.Report = examinationReport.Report;
            examinationReportDTO.Recipes = _recipeMapper.ToDTO(examinationReport.Recipes);

            return examinationReportDTO;
        }

        public List<ExaminationReportDTO> ToDTO(List<ExaminationReport> examinationReports)
        {
            List<ExaminationReportDTO> examinationReportDTOs = new List<ExaminationReportDTO>();
            foreach (var examinationReport in examinationReports)
            {
                ExaminationReportDTO examinationReportDTO = new ExaminationReportDTO();
                examinationReportDTO.ExaminationReportId = examinationReport.ExaminationReportId;
                examinationReportDTO.Symptoms = _symptomMapper.ToDTO(examinationReport.Symptoms);
                examinationReportDTO.Report = examinationReport.Report;
                examinationReportDTO.Recipes = _recipeMapper.ToDTO(examinationReport.Recipes);
                examinationReportDTOs.Add(examinationReportDTO);
            }

            return examinationReportDTOs;
        }

        public ExaminationReport ToModel(ExaminationReportDTO examinationReportDTO)
        {
            ExaminationReport examinationReport = new ExaminationReport();
            examinationReport.ExaminationReportId = examinationReportDTO.ExaminationReportId;
            examinationReport.Symptoms = _symptomMapper.ToModel(examinationReportDTO.Symptoms);
            examinationReport.Report = examinationReportDTO.Report;
            examinationReport.Recipes = _recipeMapper.ToModel(examinationReportDTO.Recipes);

            return examinationReport;
        }

        public List<ExaminationReport> ToModel(List<ExaminationReportDTO> examinationReportDTOs)
        {
            List<ExaminationReport> examinationReports = new List<ExaminationReport>();
            foreach (var examinationReportDTO in examinationReportDTOs)
            {
                ExaminationReport examinationReport = new ExaminationReport();
                examinationReport.ExaminationReportId = examinationReportDTO.ExaminationReportId;
                examinationReport.Symptoms = _symptomMapper.ToModel(examinationReportDTO.Symptoms);
                examinationReport.Report = examinationReportDTO.Report;
                examinationReport.Recipes = _recipeMapper.ToModel(examinationReportDTO.Recipes);
                examinationReports.Add(examinationReport);
            }

            return examinationReports;
        }
    }
}
