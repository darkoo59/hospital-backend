using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class RoomMapper : IGenericMapper<Room, RoomDTO>
    {
        private readonly IGenericMapper<Bed, BedDTO> _bedMapper;

        public RoomMapper(IGenericMapper<Bed, BedDTO> bedMapper) {
            _bedMapper = bedMapper;
        }

        public RoomDTO ToDTO(Room room)
        {
            RoomDTO roomDTO = new RoomDTO();
            roomDTO.Id = room.Id;
            roomDTO.Number = room.Number;
            roomDTO.FloorId = room.FloorId;
            roomDTO.BuildingId = room.BuildingId;
            roomDTO.Description = room.Description;
            if (room.Type == HospitalLibrary.HospitalMap.Enums.RoomType.AppointmentRoom)
            {
                roomDTO.Type = "Appointment room";
            }
            else if (room.Type == HospitalLibrary.HospitalMap.Enums.RoomType.OperationRoom)
            {
                roomDTO.Type = "Operation room";
            }
            else if (room.Type == HospitalLibrary.HospitalMap.Enums.RoomType.StorageRoom) {
                roomDTO.Type = "Storage room";
            }
            roomDTO.X = room.X;
            roomDTO.Y = room.Y;
            roomDTO.Width = room.Width;
            roomDTO.Height = room.Height;
            roomDTO.Beds = _bedMapper.ToDTO(room.Beds);

            return roomDTO;
            
        }

        public List<RoomDTO> ToDTO(List<Room> rooms)
        {
            List<RoomDTO> roomDTOs = new List<RoomDTO>();
            foreach (Room room in rooms) {
                RoomDTO roomDTO = new RoomDTO();
                roomDTO.Id = room.Id;
                roomDTO.Number = room.Number;
                roomDTO.FloorId = room.FloorId;
                roomDTO.BuildingId = room.BuildingId;
                roomDTO.Description = room.Description;
                if (room.Type == HospitalLibrary.HospitalMap.Enums.RoomType.AppointmentRoom)
                {
                    roomDTO.Type = "Appointment room";
                }
                else if (room.Type == HospitalLibrary.HospitalMap.Enums.RoomType.OperationRoom)
                {
                    roomDTO.Type = "Operation room";
                }
                else if (room.Type == HospitalLibrary.HospitalMap.Enums.RoomType.StorageRoom)
                {
                    roomDTO.Type = "Storage room";
                }
                roomDTO.X = room.X;
                roomDTO.Y = room.Y;
                roomDTO.Width = room.Width;
                roomDTO.Height = room.Height;
                roomDTO.Beds = _bedMapper.ToDTO(room.Beds);
                roomDTOs.Add(roomDTO);
            }

            return roomDTOs;

        }

        public Room ToModel(RoomDTO roomDTO)
        {
            Room room = new Room();
            room.Id = roomDTO.Id;
            room.Number = roomDTO.Number;
            room.FloorId = roomDTO.FloorId;
            room.BuildingId = roomDTO.BuildingId;
            room.Description = roomDTO.Description;
            if (roomDTO.Type.Equals("Appointment room"))
            { 
                room.Type = HospitalLibrary.HospitalMap.Enums.RoomType.AppointmentRoom;
            }
            else if (roomDTO.Type.Equals("Operation room"))
            {
                room.Type = HospitalLibrary.HospitalMap.Enums.RoomType.OperationRoom;
            }
            else if (roomDTO.Type.Equals("Storage room"))
            {
                room.Type = HospitalLibrary.HospitalMap.Enums.RoomType.StorageRoom;
            }
            room.X = roomDTO.X;
            room.Y = roomDTO.Y;
            room.Width = roomDTO.Width;
            room.Height = roomDTO.Height;
            room.Beds = _bedMapper.ToModel(roomDTO.Beds);

            return room;
        }

        public List<Room> ToModel(List<RoomDTO> roomDTOs)
        {
            List<Room> rooms = new List<Room>();
            foreach (var roomDTO in roomDTOs) {
                Room room = new Room();
                room.Id = roomDTO.Id;
                room.Number = roomDTO.Number;
                room.FloorId = roomDTO.FloorId;
                room.BuildingId = roomDTO.BuildingId;
                room.Description = roomDTO.Description;
                if (roomDTO.Type.Equals("Appointment room"))
                {
                    room.Type = HospitalLibrary.HospitalMap.Enums.RoomType.AppointmentRoom;
                }
                else if (roomDTO.Type.Equals("Operation room"))
                {
                    room.Type = HospitalLibrary.HospitalMap.Enums.RoomType.OperationRoom;
                }
                else if (roomDTO.Type.Equals("Storage room"))
                {
                    room.Type = HospitalLibrary.HospitalMap.Enums.RoomType.StorageRoom;
                }
                room.X = roomDTO.X;
                room.Y = roomDTO.Y;
                room.Width = roomDTO.Width;
                room.Height = roomDTO.Height;
                room.Beds = _bedMapper.ToModel(roomDTO.Beds);
                rooms.Add(room);
            }

            return rooms;
        }
    }
}
