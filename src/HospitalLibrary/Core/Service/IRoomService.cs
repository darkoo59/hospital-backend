using HospitalLibrary.Core.Model;
using HospitalLibrary.HospitalMap.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);
        Room GetByNumber(string number);
        IEnumerable<Room> GetRooms(string buildingId, int floorId);
        IEnumerable<Equipment> GetEquipment(int id);
		IEnumerable<Equipment> GetAllEquipment();
		IEnumerable<Room> SearchForEquipment(string query);
        void Create(Room room);
        void Update(Room room);
        void Delete(Room room);
        void DeleteRequest(MoveRequest request);
        MoveRequest GetRequestById(int id);
        IEnumerable<MoveRequest> GetRequestsForRoom(int roomId);
        void MoveEquipment(MoveRequest moveRequest);
        void AddMoveRequest(MoveRequest moveRequest);
        void AddRenovationSplitRequest(MoveRequest renovationRequest);
        void AddRenovationMergeRequest(MoveRequest renovationRequest);
        bool CheckMoveRequests();
        IEnumerable<DateTime> FindFreeTimeSlots(FreeAppointmentRequest freeAppointmentRequest);
        void RenovationSplitOneRoom(MoveRequest renovationRequest);
        void RenovationMergeTwoRooms(MoveRequest renovationRequest);

    }
}
