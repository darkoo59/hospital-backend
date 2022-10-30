using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);
        Room GetByNumber(string number);
        IEnumerable<Room> GetRooms(string buildingId, int floorId);
        void Create(Room room);
        void Update(Room room);
        void Delete(Room room);
    }
}
