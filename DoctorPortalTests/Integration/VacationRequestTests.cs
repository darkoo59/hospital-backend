using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalTests.setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalTests.Integration
{
    public class VacationRequestTests : BaseIntegrationTest
    {
        public VacationRequestTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static VacationRequestController SetupController(IServiceScope scope)
        {
            return new VacationRequestController(scope.ServiceProvider.GetRequiredService<IVacationRequestService>(), scope.ServiceProvider.GetRequiredService<IGenericMapper<VacationRequest, VacationRequestDTO>>());
        }

        [Fact,Priority(2)]
        public void Create_correct_vacation_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            VacationRequestDTO vacationRequestDTO = new VacationRequestDTO(13,DateTime.Now.AddDays(10),DateTime.Now.AddDays(15),1,"Approved","NoUrgent","NoReason");

            var result = ((CreatedAtActionResult)controller.Create(vacationRequestDTO))?.Value as VacationRequest;

            Assert.NotNull(result);
        }
    }
}
