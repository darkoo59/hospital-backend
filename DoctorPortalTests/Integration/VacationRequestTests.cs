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
using Shouldly;
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

        [Fact]
        public void Create_correct_vacation_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            VacationRequestDTO vacationRequestDTO = new VacationRequestDTO(13, DateTime.Now.AddDays(10), DateTime.Now.AddDays(15), 1, "Approved", "NoUrgent", "NoReason");

            var result = ((CreatedAtActionResult)controller.Create(vacationRequestDTO))?.Value as VacationRequest;

            Xunit.Assert.Equal(result.Urgency, "NoUrgent");
        }

        [Fact]
        public void Create_bad_vacation_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            VacationRequestDTO vacationRequestDTO = new VacationRequestDTO(4, DateTime.Now.AddDays(4), DateTime.Now.AddDays(15), 2, "Approved", "NoUrgent", "NoReason");

            var result = ((BadRequestResult)controller.Create(vacationRequestDTO))?.ShouldBeOfType<BadRequestResult>();

            result.ShouldBeOfType<BadRequestResult>();
        }


        [Fact]
        public void ApproveRequest()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            int VacationRequestId = 2;
            var result = controller.ApproveRequest(VacationRequestId);

            Xunit.Assert.NotNull(result);

        }
        [Fact]
        public void NotApproveRequest()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            int VacationRequestId = 2;
            var result = controller.NotApproveRequest(VacationRequestId);

            Xunit.Assert.NotNull(result);

        }



    }
}