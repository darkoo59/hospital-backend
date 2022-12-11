using HospitalLibrary.Core.Model;
using HospitalLibrary.HospitalMap.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
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
            return _context.Rooms.Include(r => r.Beds).ToList();
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
        public void Update1(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;

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
            foreach (Equipment equipment in _context.Equipment)
            {
                if (equipment.RoomId == id)
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
            equipmentList = _context.Equipment.Where(e => e.Name.ToLower().Contains(query.ToLower())).ToList();
            foreach (Equipment equipment in equipmentList)
            {
                rooms.Add(_context.Rooms.FirstOrDefault(r => r.Id == equipment.RoomId));
            }
            return rooms;
        }

        public void ChangeEquipmentQuantity(Equipment equipment, int quantity)
        {
            Equipment eqToBeUpdated = _context.Equipment.Find(equipment.Id);
            eqToBeUpdated.Quantity += quantity;
            _context.Update(eqToBeUpdated);
            _context.SaveChanges();
        }

        public void AddEquipment(MoveRequest moveRequest,Equipment equipment) 
        {
            Equipment existingEquipment = _context.Equipment.Where(e => e.RoomId == moveRequest.toRoomId).Where(e => e.Name == moveRequest.equipment).FirstOrDefault();
            if(existingEquipment != null)
            {
                ChangeEquipmentQuantity(existingEquipment, moveRequest.quantity);
            }
            else
            {
                _context.Equipment.Add(equipment);
            }
            _context.SaveChanges();
        }

        public void MoveEquipment(MoveRequest moveRequest) 
        {
            List<Equipment> eqList = _context.Equipment.Where(e => e.RoomId == moveRequest.fromRoomId).ToList();
            foreach(Equipment eq in eqList)
            {
                if (moveRequest.equipment == eq.Name)
                {
                    ChangeEquipmentQuantity(eq, -moveRequest.quantity);
                    int newId = _context.Equipment.OrderBy(e => e.Id).Last().Id + 1;
                    Equipment EqToBeAdded = new Equipment { Id = newId, RoomId = moveRequest.toRoomId, EquipmentType = eq.EquipmentType, Name = eq.Name, Quantity = moveRequest.quantity };
                    AddEquipment(moveRequest, EqToBeAdded);
                }
            }
        }

        public void AddMoveRequest(MoveRequest moveRequest)
        {
            _context.MoveRequests.Add(moveRequest);
            _context.SaveChanges();
        }

        public bool CheckMoveRequests()
        {
            bool res = false;
            List<MoveRequest> moveRequests = _context.MoveRequests.ToList();
            foreach(MoveRequest mvr in moveRequests)
            {
                if(mvr.chosenStartTime < DateTime.Now)
                {
                    //trebace posle verovatno da bi zauzeo tu sobu kao
                }
                if(mvr.chosenStartTime + mvr.duration < DateTime.Now)
                {
                    MoveEquipment(mvr);
                    _context.MoveRequests.Remove(mvr);
                    _context.SaveChanges();
                    res = true;
                }
            }
            return res;
        }
    }
}
