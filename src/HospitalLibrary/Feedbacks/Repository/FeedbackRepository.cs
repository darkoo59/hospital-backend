using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Feedbacks.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HospitalDbContext _context;

        public FeedbackRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        public IEnumerable<Feedback> GetAllPublic()
        {
            return _context.Feedbacks.ToList().Where(feedback => feedback.IsDisplayedPublic == true && feedback.Privatisation == false);
        }

        public IEnumerable<Feedback> GetAllPublicNotPublished()
        {
            return _context.Feedbacks.ToList().Where(feedback => feedback.IsDisplayedPublic == false && feedback.Privatisation == false);
        }

        public IEnumerable<Feedback> GetAllPrivate()
        {
            return _context.Feedbacks.ToList().Where(feedback => feedback.Privatisation == true && feedback.IsDisplayedPublic == false);
        }

        public Feedback GetById(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public void Create(Feedback feedback)
        {
            DateTime timeOfCreation = DateTime.Today;
            string creationOfFeedback = timeOfCreation.ToString("dd.MM.yyyy.");
            feedback.Date = creationOfFeedback;
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void Update(Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public void Delete(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            _context.SaveChanges();
        }
    }
}
