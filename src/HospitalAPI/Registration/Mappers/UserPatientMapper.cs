using HospitalAPI.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.SharedModel;
using System.Collections.Generic;

namespace HospitalAPI.Registration.Mappers
{
    public class UserPatientMapper : IGenericMapper<User, PatientDTO>
    {
        public PatientDTO ToDTO(User model)
        {
            throw new System.NotImplementedException();
        }

        public List<PatientDTO> ToDTO(List<User> model)
        {
            throw new System.NotImplementedException();
        }

        public User ToModel(PatientDTO dto)
        {
            User user = new User();

            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Role = UserRole.patient;

            return user;
        }

        public List<User> ToModel(List<PatientDTO> dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
