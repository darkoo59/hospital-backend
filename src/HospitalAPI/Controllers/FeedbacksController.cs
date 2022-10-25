using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
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
            return Ok(_feedbackService.GetAll());
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
    }
}
