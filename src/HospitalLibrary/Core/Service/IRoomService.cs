using HospitalLibrary.Core.Model;
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
        IEnumerable<Room> SearchForEquipment(string query);
        void Create(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
