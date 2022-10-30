using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IFeedbackRepository
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
