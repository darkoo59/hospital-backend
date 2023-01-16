using HospitalLibrary.Core.Repository;
using HospitalLibrary.EventSourcing.Infrastructure;
using HospitalLibrary.EventSourcing.Model;
using HospitalLibrary.EventSourcing.Model.ExaminationEvents;
using HospitalLibrary.EventSourcing.Projections.Examination;
using HospitalLibrary.EventSourcing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Service
{
    public class ExaminationService : IExaminationService
    {
        private readonly IExaminationRepository _repository;
        private readonly IExaminationReportRepository _examinationReportRepository;

        public ExaminationService(IExaminationRepository repository, IExaminationReportRepository examinationReportRepository)
        {
            _repository = repository;
            _examinationReportRepository = examinationReportRepository;
        }

        public void AddRecipes(int id)
        {
            var examination = _repository.FindBy(id);
            examination.AddRecipes();
            _repository.Save(examination);
        }

        public void AddReport(int id)
        {
            var examination = _repository.FindBy(id);
            examination.AddReport();
            _repository.Save(examination);
        }

        public void AddSymptoms(int id)
        {
            var examination = _repository.FindBy(id);
            examination.AddSymptoms();
            _repository.Save(examination);
        }

        public void FinishExamination(int id)
        {
            var examination = _repository.FindBy(id);
            examination.Finish();
            _repository.Save(examination);
        }

        public void StartExamination(int appointmentId)
        {
            var examination = new Examination(appointmentId);
            _repository.Add(examination);
        }

        public AverageNumberOfSteps GetAverageNumberOfSteps()
        {
            int totalNumOfEvents = 0;
            foreach (var examinationReport in _examinationReportRepository.GetAll())
            {
                var streamName = string.Format("{0}-{1}", typeof(Examination).Name, examinationReport.AppointmentId.ToString());
                totalNumOfEvents += _repository.GetStream(streamName, 0, int.MaxValue).ToList().Count;
            }

            if (_examinationReportRepository.GetAll().ToList().Count > 0)
            {
                double avgNumOfSteps = totalNumOfEvents / _examinationReportRepository.GetAll().ToList().Count;
                return new AverageNumberOfSteps(avgNumOfSteps);
            }

            return new AverageNumberOfSteps(0);
        }

        public AverageNumberOfVisitsToCertainStep GetAverageNumberOfVisitsToCertainStep()
        {
            double startExaminationCnt = 0;
            double selectSymptomsCnt= 0;
            double enterReportCnt = 0;
            double createRecipesCnt = 0;
            double finishExaminationCnt = 0;
            foreach (var examinationReport in _examinationReportRepository.GetAll())
            {
                var streamName = string.Format("{0}-{1}", typeof(Examination).Name, examinationReport.AppointmentId.ToString());
                foreach (var @event in _repository.GetStream(streamName, 0, int.MaxValue))
                {
                    if (@event.GetType() == typeof(ExaminationStarted))
                        startExaminationCnt++;
                    else if (@event.GetType() == typeof(SymptomsSelected))
                        selectSymptomsCnt++;
                    else if (@event.GetType() == typeof(ReportEntered))
                        enterReportCnt++;
                    else if (@event.GetType() == typeof(RecipesCreated))
                        createRecipesCnt++;
                    else if (@event.GetType() == typeof(ExaminationFinished))
                        finishExaminationCnt++;
                }
            }

            int numOfStreams = _examinationReportRepository.GetAll().ToList().Count;

            double avgStartExaminationSteps = startExaminationCnt / numOfStreams;
            double avgSelectSymptomsSteps = selectSymptomsCnt / numOfStreams;
            double avgEnterReportSteps = enterReportCnt / numOfStreams;
            double avgCreateRecipesSteps = createRecipesCnt / numOfStreams;
            double avgFinishExaminationSteps = finishExaminationCnt / numOfStreams;

            return new AverageNumberOfVisitsToCertainStep(avgStartExaminationSteps, avgSelectSymptomsSteps, avgEnterReportSteps, avgCreateRecipesSteps, avgFinishExaminationSteps);
        }

        public AverageDurationOfExam GetAverageDurationOfExam()
        {
            double totalTimeInSeconds = 0;
            foreach (var examinationReport in _examinationReportRepository.GetAll())
            {
                var streamName = string.Format("{0}-{1}", typeof(Examination).Name, examinationReport.AppointmentId.ToString());
                List<Object> events = _repository.GetStream(streamName, 0, int.MaxValue).ToList();
                DomainEvent lastEvent = (DomainEvent)events[events.Count - 1];
                DomainEvent firstEvent = (DomainEvent)events[0];
                TimeSpan ts = lastEvent.Time.Subtract(firstEvent.Time);
                totalTimeInSeconds += GetSeconds(ts);
            }

            double averageDurationInSeconds = totalTimeInSeconds / _examinationReportRepository.GetAll().ToList().Count;
            return new AverageDurationOfExam(averageDurationInSeconds);
        }

        private static int GetSeconds(TimeSpan ts)
        {
            return ((ts.Days * 24) * 3600) + (ts.Hours * 3600) + (ts.Minutes * 60) + ts.Seconds;
        }

        public AverageDurationOfEachStep GetAverageDurationOfEachStep()
        {
            double selectSymptomsCnt = 0;
            double selectSymptomsInSeconds = 0;
            double enterReportCnt = 0;
            double enterReportInSeconds = 0;
            double createRecipesCnt = 0;
            double createRecipesInSeconds = 0;
            double finishExaminationCnt = 0;
            double finishExaminationInSeconds = 0;
            foreach (var examinationReport in _examinationReportRepository.GetAll())
            {
                var streamName = string.Format("{0}-{1}", typeof(Examination).Name, examinationReport.AppointmentId.ToString());
                List<object> events = _repository.GetStream(streamName, 0, int.MaxValue).ToList();
                for (int i = 1; i < events.Count; i++)
                {
                    if (events[i].GetType() == typeof(SymptomsSelected))
                    {
                        selectSymptomsCnt++;
                        DomainEvent d1 = (DomainEvent)events[i];
                        DomainEvent d2 = (DomainEvent)events[i - 1];
                        selectSymptomsInSeconds += GetSeconds(d1.Time.Subtract(d2.Time));
                    }
                    else if (events[i].GetType() == typeof(ReportEntered))
                    {
                        enterReportCnt++;
                        DomainEvent d1 = (DomainEvent)events[i];
                        DomainEvent d2 = (DomainEvent)events[i - 1];
                        enterReportInSeconds += GetSeconds(d1.Time.Subtract(d2.Time));
                    }
                    else if (events[i].GetType() == typeof(RecipesCreated))
                    {
                        createRecipesCnt++;
                        DomainEvent d1 = (DomainEvent)events[i];
                        DomainEvent d2 = (DomainEvent)events[i - 1];
                        createRecipesInSeconds += GetSeconds(d1.Time.Subtract(d2.Time));
                    }
                    else if (events[i].GetType() == typeof(ExaminationFinished))
                    {
                        finishExaminationCnt++;
                        DomainEvent d1 = (DomainEvent)events[i];
                        DomainEvent d2 = (DomainEvent)events[i - 1];
                        finishExaminationInSeconds += GetSeconds(d1.Time.Subtract(d2.Time));
                    }
                }
            }

            return new AverageDurationOfEachStep(selectSymptomsInSeconds / selectSymptomsCnt, enterReportInSeconds / enterReportCnt, createRecipesInSeconds / createRecipesCnt, finishExaminationInSeconds / finishExaminationCnt);
        }

        public AverageDurationOfSingleStep GetAverageDurationOfSingleStep()
        {
            AverageDurationOfExam averageDurationOfExam = GetAverageDurationOfExam();
            return new AverageDurationOfSingleStep(averageDurationOfExam.DurationInSeconds / 4);
        }
    }
}
