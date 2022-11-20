using HospitalLibrary.Core.Model;
using HospitalLibrary.HospitalMap.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.HospitalMap.Repository
{
    public class RoomMapRepository : IRoomMapRepository
    {
        private readonly HospitalDbContext _context;
        List<RoomMap> roomsMap;

        public RoomMapRepository(HospitalDbContext context)
        {
            _context = context;
            List<Room> rooms = _context.Rooms.ToList();
            roomsMap = new List<RoomMap>();
            foreach (Room room in rooms)
            {
                RoomMap newRoomMap = new RoomMap();
                newRoomMap.Id = room.Id;
                newRoomMap.FloorId = room.FloorId;
                newRoomMap.Number = room.Number;
                newRoomMap.BuildingId = room.BuildingId;
                newRoomMap.X = room.X;
                newRoomMap.Y = room.Y;
                newRoomMap.Height = room.Height;
                newRoomMap.Width = room.Width;

                roomsMap.Add(newRoomMap);
            }
        }

        public IEnumerable<RoomMap> GetAll()
        {
            return roomsMap;
        }

        public RoomMap GetById(int id)
        {
            foreach (RoomMap r in roomsMap)
            {
                if (r.Id == id)
                    return r;
            }
            return null;
        }

        public RoomMap GetByNumber(string number)
        {
            foreach (RoomMap r in roomsMap)
            {
                if (r.Number == number)
                    return r;
            }
            return null;
        }

        public IEnumerable<RoomMap> GetRooms(string buildingId, int floorId)
        {
            List<RoomMap> res = new List<RoomMap>();
            foreach (RoomMap r in roomsMap)
            {
                if (r.BuildingId == buildingId && r.FloorId == floorId)
                {
                    res.Add(r);
                }
            }
            return res;
        }
    }
}
