using Xunit.Priority;
using Xunit;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;
using System;
using System.Threading;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.Features.EquipmentTenders.DTO;
using IntegrationLibrary.Features.EquipmentTenders.DTO.CreateDTO;
using IntegrationLibrary.Features.EquipmentTenders.DTO.UserDTO;

namespace IntegrationTests.EquipmentTenderTests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("collection")]
    public class IntegrationTests
    {
        private TestDatabaseFactory<Startup> Factory { get; }
        public IntegrationTests(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }

        private static EquipmentTenderController SetupController(IServiceScope scope, HttpContext httpContext)
        {
            EquipmentTenderController controller = new(scope.ServiceProvider.GetRequiredService<IEquipmentTenderService>())
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
            return controller;
        }

        [Fact, Priority(10)]
        public void Create_Equipment_Tender()
        {
            IServiceScope scope = Factory.Services.CreateScope();
            
            MockHttpContext httpContext = new("email2@gmail.com");
            EquipmentTenderController controller = SetupController(scope, httpContext);

            CreateEquipmentTenderDTO dto = new() 
            { 
                Title = "naslov",
                ExpiresOn = new DateTime(),
                Description = "",
                Requirements = new List<TenderRequirementDTO>()
            };

            controller.Create(dto);

            EquipmentTenderDTO result = ((OkObjectResult)controller.GetById(4)).Value as EquipmentTenderDTO;

            Assert.Equal(4, result.Id);
            Assert.Equal(dto.Title, result.Title);
        }

        [Fact, Priority(10)]
        public void Create_Tender_Application()
        {
            IServiceScope scope = Factory.Services.CreateScope();

            MockHttpContext httpContext = new("email2@gmail.com");
            EquipmentTenderController controller = SetupController(scope, httpContext);

            CreateTenderApplicationDTO dto = new()
            {
                Note = "note",
                EquipmentTenderId = 1,
                TenderOffers = new List<CreateTenderOfferDTO>()
            };

            controller.CreateApplication(dto);

            UserTenderApplicationDTO result = ((OkObjectResult)controller.GetApplicationById(1)).Value as UserTenderApplicationDTO;

            Assert.Equal(1, result.Id);
            Assert.Equal(dto.Note, result.Note);
            Assert.Equal(dto.EquipmentTenderId, result.EquipmentTender.Id);
        }

        [Fact, Priority(11)]
        public void Set_Winner()
        {
            IServiceScope scope = Factory.Services.CreateScope();

            MockHttpContext httpContext = new("email2@gmail.com");
            EquipmentTenderController controller = SetupController(scope, httpContext);

            controller.SetWinner(1);
            UserTenderApplicationDTO result = ((OkObjectResult)controller.GetApplicationById(1)).Value as UserTenderApplicationDTO;

            Assert.True(result.HasWon);
        }

        [Fact, Priority(12)]
        public void Delete_Tender_ApplicatioN()
        {
            IServiceScope scope = Factory.Services.CreateScope();

            MockHttpContext httpContext = new("email2@gmail.com");
            EquipmentTenderController controller = SetupController(scope, httpContext);

            controller.DeleteApplicationByIdAndBloodBank(1);

            Assert.Throws<Exception>(() => controller.GetApplicationById(1));
        }
    }

   
    public class MockHttpContext : HttpContext
    {
        public MockHttpContext(string email)
        {
            CustomPrincipal principal = new(email);
            User = principal;
        }

        public override ClaimsPrincipal User { get;  set; }

        public override IFeatureCollection Features => throw new NotImplementedException();

        public override HttpRequest Request => null;

        public override HttpResponse Response => throw new NotImplementedException();

        public override ConnectionInfo Connection => throw new NotImplementedException();

        public override WebSocketManager WebSockets => throw new NotImplementedException();

        public override IDictionary<object, object> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override IServiceProvider RequestServices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override CancellationToken RequestAborted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string TraceIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Abort()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomPrincipal : ClaimsPrincipal
    {
        public CustomPrincipal(string email)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, email)
            };
            AddIdentity(new ClaimsIdentity(claims));
        }
    }
}
