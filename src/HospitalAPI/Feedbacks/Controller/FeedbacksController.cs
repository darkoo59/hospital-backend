using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Feedbacks.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: api/feedbacks
        [HttpGet]
        public ActionResult GetAll()
        {
            string privatisation = HttpContext.Request.Query["private"].ToString();
            if (privatisation.Length == 0)
            {
                return Ok(_feedbackService.GetAll());
            }
            else if (privatisation.Equals("true"))
            {
                return Ok(_feedbackService.GetAllPrivate());
            }
            else
            {
                return Ok(_feedbackService.GetAllPublicNotPublished());
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
