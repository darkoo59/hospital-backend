using HospitalLibrary.HospitalMap.Model;
using HospitalLibrary.HospitalMap.Service;
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
    public class RoomsMapController : ControllerBase
    {
        private readonly IRoomMapService _roomMapService;

        public RoomsMapController(IRoomMapService roomMapService)
        {
            _roomMapService = roomMapService;
        }

        // GET: api/roomsMap
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_roomMapService.GetAll());
        }

        // GET api/roomsMap/2
        [HttpGet("id/{id}")]
        public ActionResult GetById(int id)
        {
            var room = _roomMapService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpGet("number/{number}")]
        public ActionResult GetByNumber(string number)
        {
            var room1 = _roomMapService.GetByNumber(number);
            if (room1 == null)
            {
                return NotFound();
            }
            return Ok(room1);
        }

        [HttpGet("{buildingId}/{floorId}")]
        public ActionResult GetRoomsByBuildingFloor(string buildingId, int floorId)
        {
            List<RoomMap> rooms = (List<RoomMap>)_roomMapService.GetRooms(buildingId, floorId);
            if (rooms.Count == 0)
            {
                return NotFound();

            }
            return Ok(_roomMapService.GetRooms(buildingId, floorId));

        }

    }
}
