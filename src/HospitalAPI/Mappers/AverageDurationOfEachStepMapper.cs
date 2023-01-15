using HospitalAPI.Dtos;
using HospitalLibrary.EventSourcing.Projections.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AverageDurationOfEachStepMapper : IGenericMapper<AverageDurationOfEachStep, AverageDurationOfEachStepDTO>
    {
        public AverageDurationOfEachStepDTO ToDTO(AverageDurationOfEachStep model)
        {
            return new AverageDurationOfEachStepDTO(model.SelectSymptomsInSeconds, model.EnterReportInSeconds, model.CreateRecipesInSeconds, model.FinishExaminationInSeconds);
        }

        public List<AverageDurationOfEachStepDTO> ToDTO(List<AverageDurationOfEachStep> model)
        {
            throw new NotImplementedException();
        }

        public AverageDurationOfEachStep ToModel(AverageDurationOfEachStepDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<AverageDurationOfEachStep> ToModel(List<AverageDurationOfEachStepDTO> dto)
        {
            throw new NotImplementedException();
        }
    }
}
