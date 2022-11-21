using HospitalLibrary.Feedbacks.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Feedbacks.Service
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetAllPublic();
        Feedback GetById(int id);
        void Create(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
        public IEnumerable<Feedback> GetAllPrivate();
        public IEnumerable<Feedback> GetAllPublicNotPublished();
    }
}
