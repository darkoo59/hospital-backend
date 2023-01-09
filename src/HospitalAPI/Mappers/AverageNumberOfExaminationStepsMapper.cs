using HospitalAPI.Dtos;
using HospitalLibrary.EventSourcing.Projections.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AverageNumberOfExaminationStepsMapper : IGenericMapper<AverageNumberOfSteps, AverageNumberOfExaminationStepsDTO>
    {
        public AverageNumberOfExaminationStepsDTO ToDTO(AverageNumberOfSteps averageNumberOfSteps)
        {
            return new AverageNumberOfExaminationStepsDTO(averageNumberOfSteps.AvgNumOfSteps); 
        }

        public List<AverageNumberOfExaminationStepsDTO> ToDTO(List<AverageNumberOfSteps> model)
        {
            throw new NotImplementedException();
        }

        public AverageNumberOfSteps ToModel(AverageNumberOfExaminationStepsDTO averageNumberOfExaminationStepsDTO)
        {
            return new AverageNumberOfSteps(averageNumberOfExaminationStepsDTO.AvgNumOfSteps);
        }

        public List<AverageNumberOfSteps> ToModel(List<AverageNumberOfExaminationStepsDTO> dto)
        {
            throw new NotImplementedException();
        }
    }
}
