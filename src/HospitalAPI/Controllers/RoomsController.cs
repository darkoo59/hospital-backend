using System.Collections.Generic;
using System.Linq;
using HospitalAPI.Dtos;
using HospitalAPI.Mappers;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.HospitalMap.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomsController : ControllerBase
	{
		private readonly IRoomService _roomService;
		private readonly IGenericMapper<Room, RoomDTO> _roomMapper;

		public RoomsController(IRoomService roomService, IGenericMapper<Room, RoomDTO> roomMapper)
		{
			_roomService = roomService;
			_roomMapper = roomMapper;
		}

		// GET: api/rooms
		[HttpGet]
		public ActionResult GetAll()
		{
			return Ok(_roomMapper.ToDTO(_roomService.GetAll().ToList()));
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

		[HttpPost("moveRequests")]
		public ActionResult AddMoveRequest(MoveRequest moveRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_roomService.AddMoveRequest(moveRequest);
			return Ok(moveRequest);
		}
		[HttpPost("renovationSplit")]
		public ActionResult AddRenovationSplitRequest(MoveRequest renovationRequest)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_roomService.AddRenovationSplitRequest(renovationRequest);
			return Ok(renovationRequest);
		}

        [HttpPost("renovationMerge")]
        public ActionResult AddRenovationMergeRequest(MoveRequest renovationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _roomService.AddRenovationMergeRequest(renovationRequest);
            return Ok(renovationRequest);
        }

        [HttpGet("moveRequests/check")]
		public ActionResult CheckMoveRequests()
		{
			return Ok(_roomService.CheckMoveRequests());
		}

		/*        [HttpPatch]
				public ActionResult MoveEquipment(MoveRequest moveRequest)
				{
					if (!ModelState.IsValid)
					{
						return BadRequest(ModelState);
					}
					_roomService.MoveEquipment(moveRequest);
					return Ok(moveRequest);
				}*/



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



		[HttpPost("freeAppointments")]
		public ActionResult GetFreeAppointments(FreeAppointmentRequestDTO freeAppointmentRequestDTO)
		{
			FreeAppointmentRequest freeAppointmentRequest = new FreeAppointmentRequest(freeAppointmentRequestDTO.FirstRoomId, freeAppointmentRequestDTO.SecondRoomId,
				freeAppointmentRequestDTO.WantedStartDate, freeAppointmentRequestDTO.WantedEndDate, freeAppointmentRequestDTO.Duration, freeAppointmentRequestDTO.DurationTimeUnit);

			return Ok(_roomService.FindFreeTimeSlots(freeAppointmentRequest));
		}

		[HttpPost("renovationSplitInstant")]
		public void RenovationSplitOneRoom(MoveRequest renovationRequest)
        {
			_roomService.RenovationSplitOneRoom(renovationRequest);
        }
		[HttpPost("renovationMergeInstant")]
		public void RenovationMergeTwoRooms(MoveRequest renovationRequest)
		{
			_roomService.RenovationMergeTwoRooms(renovationRequest);
		}
	}
}
