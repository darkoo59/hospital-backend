using HospitalAPI.Dtos;
using HospitalLibrary.EventSourcing.Projections.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class AverageDurationOfExamMapper : IGenericMapper<AverageDurationOfExam, AverageDurationOfExamDTO>
    {
        public AverageDurationOfExamDTO ToDTO(AverageDurationOfExam averageDurationOfExam)
        {
            return new AverageDurationOfExamDTO(averageDurationOfExam.DurationInSeconds);
        }

        public List<AverageDurationOfExamDTO> ToDTO(List<AverageDurationOfExam> model)
        {
            throw new NotImplementedException();
        }

        public AverageDurationOfExam ToModel(AverageDurationOfExamDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<AverageDurationOfExam> ToModel(List<AverageDurationOfExamDTO> dto)
        {
            throw new NotImplementedException();
        }
    }
}
