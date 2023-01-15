using HospitalLibrary.RenovationEventSourcing;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{

		private readonly IEventService _eventService;

		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		[HttpPost("{eventType}")]
		public ActionResult CreateEvent(string eventType)
		{
			Event newEvent = _eventService.CreateEvent(eventType);
			//return CreatedAtAction(eventType, newEvent);
			return Ok();
		}

		[HttpGet("stepsForSchedulingRenovation")]
		public ActionResult GetNumberOfStepsForSchedulingRenovation() 
		{
			return Ok();
		}

		[HttpGet("numberOfViewsForEachStep")]
		public ActionResult GetAverageNumberOfViewsForEachStep()
		{
			return Ok(_eventService.GetAverageNumberOfViewsForEachStep());
		}

		[HttpGet("numberOfViewsForEachStepCanceled")]
		public ActionResult GetAverageNumberOfViewsForEachStepCanceled()
		{
			return Ok(_eventService.GetAverageNumberOfViewsForEachStepCanceled());
		}

		[HttpGet("averagePageTimeInSeconds")]
		public ActionResult GetAveragePageTimeInSeconds()
		{
			return Ok(_eventService.GetAveragePageTimeInSeconds());
		}

		[HttpGet("averagePageTimeInSecondsCanceled")]
		public ActionResult GetAveragePageTimeInSecondsCanceled()
		{
			return Ok(_eventService.GetAveragePageTimeInSecondsCanceled());
		}

		[HttpGet("averageSchedulingTimeInSeconds")]
		public ActionResult GetAverageSchedulingTimeInSeconds()
		{
			return Ok(_eventService.GetAverageSchedulingTimeInSeconds());
		}

		[HttpGet("numberOfSuccessfulScheduling")]
		public ActionResult GetNumberOfSuccessfulScheduling()
		{
			return Ok(_eventService.GetNumberOfSuccessfulScheduling());
		}

		[HttpGet("numberOfUnsuccessfulScheduling")]
		public ActionResult GetNumberOfUnsuccessfulScheduling()
		{
			return Ok(_eventService.GetNumberOfUnsuccessfulScheduling());
		}

		[HttpGet("averageNumberOfStepsForSuccessfulSchedule")]
		public ActionResult GetAverageNumberOfStepsForSuccessfulSchedule()
		{
			return Ok(_eventService.GetAverageNumberOfStepsForSuccessfulSchedule());
		}

		[HttpGet("averageNumberOfStepsForCanceledSchedule")]
		public ActionResult GetAverageNumberOfStepsForCanceledSchedule()
		{
			return Ok(_eventService.GetAverageNumberOfStepsForCanceledSchedule());
		}

		[HttpGet("averageTimeForSuccessfulSchedule")]
		public ActionResult GetAverageTimeForSuccessfulSchedule()
		{
			return Ok(_eventService.GetAverageTimeForSuccessfulSchedule());
		}
		[HttpGet("averageTimeForCanceledSchedule")]
		public ActionResult GetAverageTimeForCanceledSchedule()
		{
			return Ok(_eventService.GetAverageTimeForCanceledSchedule());
		}
	}
}
