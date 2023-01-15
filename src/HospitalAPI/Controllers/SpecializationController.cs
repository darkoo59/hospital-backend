using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecilizationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        private readonly IGenericMapper<Specialization, SpecializationDTO> _specializationMapper;

        public SpecilizationController(ISpecializationService specializationService, IGenericMapper<Specialization,SpecializationDTO> specializationMapper)
        {
            _specializationService = specializationService;
            _specializationMapper = specializationMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_specializationMapper.ToDTO(_specializationService.GetAll().ToList()));
        }
    }
}
