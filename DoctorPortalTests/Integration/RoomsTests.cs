using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Service;
using HospitalLibrary.HospitalMap.Enums;
using HospitalLibrary.HospitalMap.Model;
using HospitalTests.setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Integration
{
    public class RoomsTests : BaseIntegrationTest 
    {
        public RoomsTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static RoomsController SetupController(IServiceScope scope)
        {
            //return new RoomsController(scope.ServiceProvider.GetRequiredService<IRoomService>());
            return null;
        }

        //[Fact]
        //public void Get_all_equipment()
        //{
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = SetupController(scope);

        //    /*List<Equipment> allEquipment = new List<Equipment>() { new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 1, RoomId = 1, Name = "Syringe", Quantity = 50 },
        //                                                                        new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 2, RoomId = 1, Name = "Tounge depressor", Quantity = 32 },
        //                                                                        new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 3, RoomId = 2, Name = "Gloves", Quantity = 50 }};*/

        //    //var result = controller.GetAllEquipment() as IEnumerable<Equipment>;
        //    var result = controller.GetAllEquipment();

        //    Assert.NotNull(result);
        //    //Assert.Equal(allEquipment, result);
        //}
        //[Fact]
        //public void Get_by_id()
        //{
        //    using var scope = Factory.Services.CreateScope();
        //    var controller = SetupController(scope);
        //    /*List<Equipment> allEquipment = new List<Equipment>() { new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 1, RoomId = 1, Name = "Syringe", Quantity = 50 },
        //                                                                        new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 2, RoomId = 1, Name = "Tounge depressor", Quantity = 32 },
        //                                                                        new Equipment() { EquipmentType = EquipmentType.Dynamic, Id = 3, RoomId = 2, Name = "Gloves", Quantity = 50 }};*/

        //    var result = controller.GetById(1);

        //    Assert.NotNull(result);
        //    //Assert.Equal(allEquipment[1],result);
        //}
    }
}
