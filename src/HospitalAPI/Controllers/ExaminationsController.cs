using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.EventSourcing.Projections.Examination;
using HospitalLibrary.EventSourcing.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationService _service;
        private readonly IGenericMapper<AverageNumberOfSteps, AverageNumberOfExaminationStepsDTO> _averageNumberOfStepsMapper;
        private readonly IGenericMapper<AverageNumberOfVisitsToCertainStep, AverageNumberOfVisitsToCertainStepDTO> _averageNumberOfVisitsToCertainStepMapper;
        private readonly IGenericMapper<AverageDurationOfExam, AverageDurationOfExamDTO> _averageDurationOfExamMapper;
        private readonly IGenericMapper<AverageDurationOfEachStep, AverageDurationOfEachStepDTO> _averageDurationOfEachStepMapper;
        private readonly IGenericMapper<AverageDurationOfSingleStep, AverageDurationOfSingleStepDTO> _averageDurationOfSingleStepMapper;

        public ExaminationsController(IExaminationService service, IGenericMapper<AverageNumberOfSteps, AverageNumberOfExaminationStepsDTO> averageNumberOfStepsMapper, IGenericMapper<AverageNumberOfVisitsToCertainStep, AverageNumberOfVisitsToCertainStepDTO> averageNumberOfVisitsToCertainStepMapper, IGenericMapper<AverageDurationOfExam, AverageDurationOfExamDTO> averageDurationOfExamMapper, IGenericMapper<AverageDurationOfEachStep, AverageDurationOfEachStepDTO> averageDurationOfEachStepMapper, IGenericMapper<AverageDurationOfSingleStep, AverageDurationOfSingleStepDTO> averageDurationOfSingleStepMapper)
        {
            _service = service;
            _averageNumberOfStepsMapper = averageNumberOfStepsMapper;
            _averageNumberOfVisitsToCertainStepMapper = averageNumberOfVisitsToCertainStepMapper;
            _averageDurationOfExamMapper = averageDurationOfExamMapper;
            _averageDurationOfEachStepMapper = averageDurationOfEachStepMapper;
            _averageDurationOfSingleStepMapper = averageDurationOfSingleStepMapper;
        }

        [HttpPost("start/{appointmentId}")]
        public ActionResult StartExamination(int appointmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.StartExamination(appointmentId);
            return Ok(appointmentId);
        }

        [HttpPost("{id}")]
        public ActionResult AddSymptoms(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddSymptoms(id);
            return Ok(id);
        }

        [HttpPost("report/{id}")]
        public ActionResult AddReport(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddReport(id);
            return Ok(id);
        }

        [HttpPost("recipes/{id}")]
        public ActionResult AddRecipes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddRecipes(id);
            return Ok(id);
        }

        [HttpPost("finish/{id}")]
        public ActionResult FinishExamination(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.FinishExamination(id);
            return Ok(id);
        }

        [HttpGet]
        public ActionResult GetAverageNumberOfExaminationSteps()
        {
            return Ok(_averageNumberOfStepsMapper.ToDTO(_service.GetAverageNumberOfSteps()));
        }

        [HttpGet("numberOfVisits")]
        public ActionResult GetAverageNumberOfVisitsToCertainStep()
        {
            return Ok(_averageNumberOfVisitsToCertainStepMapper.ToDTO(_service.GetAverageNumberOfVisitsToCertainStep()));
        }

        [HttpGet("averageTime")]
        public ActionResult GetAverageDurationOfExam()
        {
            return Ok(_averageDurationOfExamMapper.ToDTO(_service.GetAverageDurationOfExam()));
        }

        [HttpGet("averageStepDuration")]
        public ActionResult GetAverageDurationOfEachStep()
        {
            return Ok(_averageDurationOfEachStepMapper.ToDTO(_service.GetAverageDurationOfEachStep()));
        }

        [HttpGet("averageSingleStepDuration")]
        public ActionResult GetAverageDurationOfSingleStep()
        {
            return Ok(_averageDurationOfSingleStepMapper.ToDTO(_service.GetAverageDurationOfSingleStep()));
        }
    }
}
