﻿using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
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
            if (rooms.Count == 0) {
                return NotFound();
            
            }
            return Ok(_roomService.GetRooms(buildingId, floorId));

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
            return CreatedAtAction("GetById", new { id = room.RoomId }, room);
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.RoomId)
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
