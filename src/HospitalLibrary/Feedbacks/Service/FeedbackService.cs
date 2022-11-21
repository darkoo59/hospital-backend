using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Repository;
using System.Collections.Generic;


namespace HospitalLibrary.Feedbacks.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public IEnumerable<Feedback> GetAllPublic()
        {
            return _feedbackRepository.GetAllPublic();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public void Create(Feedback feedback)
        {
            _feedbackRepository.Create(feedback);
        }

        public void Update(Feedback feedback)
        {
            _feedbackRepository.Update(feedback);
        }
        public IEnumerable<Feedback> GetAllPublicNotPublished()
        {
            return _feedbackRepository.GetAllPublicNotPublished();
        }

        public void Delete(Feedback feedback)
        {
            _feedbackRepository.Delete(feedback);
        }

        public IEnumerable<Feedback> GetAllPrivate()
        {
            return _feedbackRepository.GetAllPrivate();
        }
    }
}
