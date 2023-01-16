using HospitalAPI.Dtos;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Model;
using System.Collections.Generic;

namespace HospitalAPI.Mappers
{
    public class FeedbackMapper : IGenericMapper<Feedback, FeedbackDTO>
    {
        public FeedbackMapper() 
        {

        }
        public FeedbackDTO ToDTO(Feedback model)
        {
            FeedbackDTO dto = new FeedbackDTO();
            dto.Id = model.Id;
            dto.Textt = model.Textt;
            if(model.PatientId != null)dto.PatientId = (int)model.PatientId;
            dto.Date = model.Date;
            return dto;
        }

        public List<FeedbackDTO> ToDTO(List<Feedback> model)
        {
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
            foreach (Feedback feedback in model) 
            {
                FeedbackDTO dto = new FeedbackDTO();
                dto.Id = feedback.Id;
                dto.Textt = feedback.Textt;
                if (feedback.PatientId != null) dto.PatientId = (int)feedback.PatientId;
                dto.Date = feedback.Date;
                feedbacks.Add(dto);
            }
            return feedbacks;
        }

        public Feedback ToModel(FeedbackDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public List<Feedback> ToModel(List<FeedbackDTO> dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
