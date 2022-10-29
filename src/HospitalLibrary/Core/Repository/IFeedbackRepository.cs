using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        Feedback GetById(int id);
        void Create(Feedback feedback);
        void Update(Feedback feedback);
    }
}
