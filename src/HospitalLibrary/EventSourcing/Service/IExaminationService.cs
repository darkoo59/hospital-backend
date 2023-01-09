using HospitalLibrary.EventSourcing.Projections.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Service
{
    public interface IExaminationService
    {
        void StartExamination(int appointmentId);
        void AddSymptoms(int id);
        void AddRecipes(int id);
        void AddReport(int id);
        void FinishExamination(int id);
        AverageNumberOfSteps GetAverageNumberOfSteps();
        AverageNumberOfVisitsToCertainStep GetAverageNumberOfVisitsToCertainStep();
        AverageDurationOfExam GetAverageDurationOfExam();
        AverageDurationOfEachStep GetAverageDurationOfEachStep();
        AverageDurationOfSingleStep GetAverageDurationOfSingleStep();
    }
}
