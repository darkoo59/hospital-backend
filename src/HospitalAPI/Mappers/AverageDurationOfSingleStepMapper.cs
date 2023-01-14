using HospitalAPI.Dtos;
using HospitalLibrary.EventSourcing.Projections.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AverageDurationOfSingleStepMapper : IGenericMapper<AverageDurationOfSingleStep, AverageDurationOfSingleStepDTO>
    {
        public AverageDurationOfSingleStepDTO ToDTO(AverageDurationOfSingleStep model)
        {
            return new AverageDurationOfSingleStepDTO(model.DurationInSeconds);
        }

        public List<AverageDurationOfSingleStepDTO> ToDTO(List<AverageDurationOfSingleStep> model)
        {
            throw new NotImplementedException();
        }

        public AverageDurationOfSingleStep ToModel(AverageDurationOfSingleStepDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<AverageDurationOfSingleStep> ToModel(List<AverageDurationOfSingleStepDTO> dto)
        {
            throw new NotImplementedException();
        }
    }
}
