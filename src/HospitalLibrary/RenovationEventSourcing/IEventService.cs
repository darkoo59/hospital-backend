using System.Collections.Generic;

namespace HospitalLibrary.RenovationEventSourcing
{
	public interface IEventService
	{
		Event CreateEvent(string eventType);
		Dictionary<string, float> GetAverageNumberOfViewsForEachStep();
		Dictionary<string, float> GetAverageNumberOfViewsForEachStepCanceled();
		Dictionary<string, double> GetAveragePageTimeInSeconds();
		Dictionary<string, double> GetAveragePageTimeInSecondsCanceled();
		double GetAverageSchedulingTimeInSeconds();
		int GetNumberOfSuccessfulScheduling();
		int GetNumberOfUnsuccessfulScheduling();
		double GetAverageNumberOfStepsForSuccessfulSchedule();
		double GetAverageNumberOfStepsForCanceledSchedule();
		double GetAverageTimeForSuccessfulSchedule();
		double GetAverageTimeForCanceledSchedule();
	}
}