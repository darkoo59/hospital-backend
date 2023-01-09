using HospitalAPI.Dtos;
using HospitalLibrary.EventSourcing.Projections.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AverageNumberOfVisitsToCertainStepMapper : IGenericMapper<AverageNumberOfVisitsToCertainStep, AverageNumberOfVisitsToCertainStepDTO>
    {
        public AverageNumberOfVisitsToCertainStepDTO ToDTO(AverageNumberOfVisitsToCertainStep model)
        {
            return new AverageNumberOfVisitsToCertainStepDTO(model.StartExamination, model.SelectSymptoms, model.EnterReport, model.CreateRecipes, model.FinishExamination);
        }

        public List<AverageNumberOfVisitsToCertainStepDTO> ToDTO(List<AverageNumberOfVisitsToCertainStep> model)
        {
            throw new NotImplementedException();
        }

        public AverageNumberOfVisitsToCertainStep ToModel(AverageNumberOfVisitsToCertainStepDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<AverageNumberOfVisitsToCertainStep> ToModel(List<AverageNumberOfVisitsToCertainStepDTO> dto)
        {
            throw new NotImplementedException();
        }
    }
}
