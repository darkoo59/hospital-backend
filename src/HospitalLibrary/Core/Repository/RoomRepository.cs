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
        public void ChangeEquipmentRoom(Equipment equipment, int newRoomId)
        {
            Equipment eqToBeUpdated = _context.Equipment.Find(equipment.Id);
            eqToBeUpdated.RoomId = newRoomId;
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
            moveRequest.type = "MoveRequest";
            _context.MoveRequests.Add(moveRequest);
            _context.SaveChanges();
        }
        public void AddRenovationSplitRequest(MoveRequest renovationRequest)
        {
            renovationRequest.type = "RenovationSplit";
            _context.MoveRequests.Add(renovationRequest);
            _context.SaveChanges();
        }
        public void AddRenovationMergeRequest(MoveRequest renovationRequest)
        {
            renovationRequest.type = "RenovationMerge";
            _context.MoveRequests.Add(renovationRequest);
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
                    if (mvr.type == "MoveEquipment")
                    {
                        MoveEquipment(mvr);   
                    }
                    else if(mvr.type == "RenovationSplit")
                    {
                        RenovationSplitOneRoom(mvr);
                    }
                    else if(mvr.type == "RenovationMerge")
                    {
                        RenovationMergeTwoRooms(mvr);
                    }
                    _context.MoveRequests.Remove(mvr);
                    _context.SaveChanges();
                    res = true;
                }
            }
            return res;
        }

        public IEnumerable<DateTime> FindFreeTimeSlots(FreeAppointmentRequest freeAppointmentRequest)
        {
            List<DateTime> freeTimeSlots = new List<DateTime>();
            //List<DateTime> takenTimeSlots = new List<DateTime>();
            DateTime wantedStart = freeAppointmentRequest.WantedStartDate;
            DateTime wantedEnd = freeAppointmentRequest.WantedEndDate;
            TimeSpan duration = freeAppointmentRequest.Duration;
            DateTime klizno = wantedStart;
/*            List <MoveRequest> moveRequests = _context.MoveRequests.ToList();
            foreach(MoveRequest mvr in moveRequests)
            {
                if(mvr.fromRoomId == freeAppointmentRequest.FirstRoomId || mvr.fromRoomId == freeAppointmentRequest.SecondRoomId || mvr.toRoomId == freeAppointmentRequest.FirstRoomId || mvr.toRoomId == freeAppointmentRequest.SecondRoomId)
                {
                    takenTimeSlots.Add(mvr.chosenStartTime);
                }
            }*/
            for(klizno = wantedStart; klizno + duration <= wantedEnd; klizno += duration)
            {
                freeTimeSlots.Add(klizno);
            }
            return freeTimeSlots;
        }

        public void RenovationSplitOneRoom(MoveRequest renovationRequest)
        {
            Room roomToSplit = _context.Rooms.FirstOrDefault(r => r.Id == renovationRequest.fromRoomId);
            int newId = _context.Rooms.OrderBy(r => r.Id).Last().Id + 1;
            string newNumber = roomToSplit.Number + "/2";
            Room newRoom = new Room() { Id = newId, FloorId = roomToSplit.FloorId, Number = newNumber, BuildingId = roomToSplit.BuildingId, Width = roomToSplit.Width / 2, Height = roomToSplit.Height, X = roomToSplit.X + roomToSplit.Width / 2, Y = roomToSplit.Y };
            Create(newRoom);
            roomToSplit.Width = roomToSplit.Width / 2;
            Update(roomToSplit);
        }

        public void RenovationMergeTwoRooms(MoveRequest renovationRequest)
        {
            Room room1 = _context.Rooms.FirstOrDefault(r => r.Id == renovationRequest.fromRoomId);
            Room room2 = _context.Rooms.FirstOrDefault(r => r.Id == renovationRequest.toRoomId);
            room1.Number = room1.Number + "+" + room2.Number;
            if(room1.Y != room2.Y)
            {
                room1.Height += room2.Height;
            }
            else if(room1.X != room2.X)
            {
                room1.Width += room2.Width;
            }
            List<Equipment> eqToMove = _context.Equipment.Where(e => e.RoomId == room2.Id).ToList();
            foreach(Equipment eq in eqToMove)
            {
                ChangeEquipmentRoom(eq, room1.Id);
            }
            Update(room1);
            Delete(room2);
        }
    }
}
