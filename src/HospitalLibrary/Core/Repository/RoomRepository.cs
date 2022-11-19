using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HospitalDbContext _context;

        public RoomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public Room GetByNumber(string number)
        {
            foreach (Room room in _context.Rooms)
            {
                if (room.Number == number)
                {
                    return room;
                }
            }
            return null;
        }

        public IEnumerable<Room> GetRooms(string buildingId, int floorId)
        {
            List<Room> res = new List<Room>();
            foreach (Room room in _context.Rooms)
            {
                if (room.BuildingId == buildingId && room.FloorId == floorId)
                {
                    res.Add(room);
                }
            }
            return res;
        }

        public void Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

        public IEnumerable<Equipment> GetEquipment(int id)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            foreach(Equipment equipment in _context.Equipment)
            {
                if(equipment.RoomId == id)
                {
                    equipmentList.Add(equipment);
                }
            }
            return equipmentList;
        }

		public IEnumerable<Equipment> GetAllEquipment()
		{
			List<Equipment> equipmentList = new List<Equipment>();
			foreach (Equipment equipment in _context.Equipment)
			{
			    equipmentList.Add(equipment);
			}
            return equipmentList;
		}

		public IEnumerable<Room> SearchForEquipment(string query)
        {
            List<Room> rooms = new List<Room>();
            List<Equipment> equipmentList = new List<Equipment>();
            equipmentList = _context.Equipment.Where(e => e.Name.Contains(query)).ToList();
            foreach(Equipment equipment in equipmentList)
            {
                    rooms.Add(_context.Rooms.FirstOrDefault(r => r.Id == equipment.RoomId));
            }
            return rooms;
        }
    }
}
