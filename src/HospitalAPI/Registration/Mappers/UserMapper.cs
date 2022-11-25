using System;
using System.Collections.Generic;
using HospitalAPI.Mappers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.SharedModel;

namespace HospitalAPI.Registration.Mappers
{
    public class UserMapper : IGenericMapper<User, UserDTO>
    {
        public UserDTO ToDTO(User model)
        {
            return new UserDTO(model.Email, model.Password);
        }

        public List<UserDTO> ToDTO(List<User> model)
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (User user in model)
            {
                users.Add(new UserDTO(user.Email, user.Password));
            }
            return users;
        }

        public User ToModel(UserDTO dto)
        {
            return new User(dto.Username, dto.Password);
        }

        public List<User> ToModel(List<UserDTO> dto)
        {
            List<User> users = new List<User>();
            foreach (UserDTO user in dto)
            {
                users.Add(new User(user.Username, user.Password));
            }
            return users;
        }
    }
}
