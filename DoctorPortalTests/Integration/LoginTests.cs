using HospitalAPI;
using HospitalAPI.Mappers;
using HospitalAPI.Registration.Controllers;
using HospitalAPI.Registration.Dtos;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Security;
using HospitalLibrary.SharedModel;
using HospitalTests.setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HospitalTests
{
    public class LoginTests : BaseIntegrationTest
    {
        public LoginTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static UsersController SetupController(IServiceScope scope)
        {
            return new UsersController(scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IGenericMapper<User, UserDTO>>());
        }

        [Fact]
        public void Check_if_user_exist()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            UserDTO loginDTO = new UserDTO("username", "password");

            var result = ((ObjectResult)controller.Login(loginDTO))?.Value as ContentResult;
            
            Assert.NotNull(result.Content);
        }
        [Fact]
        public void Check_if_user_not_exist()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            UserDTO loginDTO = new UserDTO("username", "passwor");

            var result = ((ObjectResult)controller.Login(loginDTO))?.Value as ContentResult;
           
            Assert.Null(result);
        }
    }
}
