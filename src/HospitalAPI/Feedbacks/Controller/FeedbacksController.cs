using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using HospitalLibrary.Registration.Service;
using HospitalLibrary.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.Feedbacks.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IGenericMapper<Feedback, FeedbackDTO> _mapper;
        private readonly IPatientService _patientService;


        public FeedbacksController(IFeedbackService feedbackService, IGenericMapper<Feedback, FeedbackDTO> mapper, IPatientService patientService)
        {
            _patientService = patientService;
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        // GET: api/feedbacks
        [HttpGet]
        public ActionResult GetAll()
        {
            string privatisation = HttpContext.Request.Query["private"].ToString();
            if (privatisation.Length == 0)
            {
                List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
                foreach(FeedbackDTO feedback in _mapper.ToDTO(_feedbackService.GetAll().ToList())) 
                {
                    Patient patient = _patientService.GetById(feedback.PatientId);
                    feedbacks.Add(new FeedbackDTO(feedback.Id, feedback.Textt, patient.Name+" "+patient.Surname, feedback.PatientId, feedback.Date));
                }
                return Ok(feedbacks);
            }
            else if (privatisation.Equals("true"))
            {
                List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
                foreach (FeedbackDTO feedback in _mapper.ToDTO(_feedbackService.GetAllPrivate().ToList()))
                {
                    Patient patient = _patientService.GetById(feedback.PatientId);
                    feedbacks.Add(new FeedbackDTO(feedback.Id, feedback.Textt, patient.Name + " " + patient.Surname, feedback.PatientId, feedback.Date));
                }
                return Ok(feedbacks);
            }
            else
            {
                List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();
                foreach (FeedbackDTO feedback in _mapper.ToDTO(_feedbackService.GetAllPublicNotPublished().ToList()))
                {
                    Patient patient = _patientService.GetById(feedback.PatientId);
                    feedbacks.Add(new FeedbackDTO(feedback.Id, feedback.Textt, patient.Name + " " + patient.Surname, feedback.PatientId, feedback.Date));
                }
                return Ok(feedbacks);
            }
        }

        // GET: api/feedbacksPublic
        [HttpGet, Route("feedbacksPublic")]
        public ActionResult GetAllPublic()
        {
            return Ok(_feedbackService.GetAllPublic());
        }

        // GET api/feedbacks/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // POST api/feedbacks
        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
        }

        // PUT api/feedbacks/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.Id)
            {
                return BadRequest();
            }

            try
            {
                _feedbackService.Update(feedback);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(feedback);
        }

        // DELETE api/feedbacks/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Delete(feedback);
            return NoContent();
        }
    }
}
