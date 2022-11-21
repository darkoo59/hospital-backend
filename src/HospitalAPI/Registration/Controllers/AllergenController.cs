using HospitalAPI.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalAPI.Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenController : ControllerBase
    {
        private readonly IAllergenService _allergenService;
        private readonly IGenericMapper<Allergen, AllergenDTO> _allergenMapper;

        public AllergenController(IAllergenService allergenService, IGenericMapper<Allergen, AllergenDTO> allergenMapper)
        {
            _allergenService = allergenService;
            _allergenMapper = allergenMapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_allergenMapper.ToDTO(_allergenService.GetAll().ToList()));
        }






    }
}
