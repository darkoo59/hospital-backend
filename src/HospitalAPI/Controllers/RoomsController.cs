using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.HospitalMap.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/rooms
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Room> rooms = (List<Room>)_roomService.GetAll();
            foreach (var room in rooms)
            {
                System.Console.WriteLine(room.Beds);
            }
            return Ok(_roomService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("id/{id}")]
        public ActionResult GetById(int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpGet("number/{number}")]
        public ActionResult GetByNumber(string number)
        {
            var room1 = _roomService.GetByNumber(number);
            if (room1 == null)
            {
                return NotFound();
            }
            return Ok(room1);       
        }

        [HttpGet("{buildingId}/{floorId}")]
        public ActionResult GetRoomsByBuildingFloor(string buildingId, int floorId)
        {
            List<Room> rooms = (List<Room>)_roomService.GetRooms(buildingId, floorId);
            if (rooms.Count == 0) 
            {
                return NotFound();           
            }
            return Ok(_roomService.GetRooms(buildingId, floorId));
        }

        // GET api/rooms/equipment/2
        [HttpGet("equipment/{id}")]
        public ActionResult GetEquipmentById(int id)
        {
            List<Equipment> equipmentList = (List<Equipment>)_roomService.GetEquipment(id);
            if (equipmentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_roomService.GetEquipment(id));
        }

		// GET api/rooms/equipment
		[HttpGet("equipment")]
		public ActionResult GetAllEquipment()
		{
			List<Equipment> equipmentList = (List<Equipment>)_roomService.GetAllEquipment();
			if (equipmentList.Count == 0)
			{
				return NotFound();
			}
			return Ok(_roomService.GetAllEquipment());
		}

		[HttpGet("equipmentSearch/{query}")]
        public ActionResult SearchForEquipment(string query)
        {
            List<Room> roomList = (List<Room>)_roomService.SearchForEquipment(query);
            if (roomList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_roomService.SearchForEquipment(query));
        }
        



        // POST api/rooms
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _roomService.Create(room);
            return CreatedAtAction("GetById", new { id = room.Id }, room);
        }
        
        [HttpPatch]
        public ActionResult MoveEquipment(MoveRequest moveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _roomService.MoveEquipment(moveRequest);
            return Ok(moveRequest);
        }
      
        

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.Id)
            {
                return BadRequest();
            }

            try
            {
                _roomService.Update(room);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(room);
        }
       
 


        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var room = _roomService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            _roomService.Delete(room);
            return NoContent();
        }
    }
}
