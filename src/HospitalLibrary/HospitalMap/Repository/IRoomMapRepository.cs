using HospitalLibrary.HospitalMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.HospitalMap.Repository
{
    public interface IRoomMapRepository
    {
        IEnumerable<RoomMap> GetAll();
        RoomMap GetById(int id);
        RoomMap GetByNumber(string number);
        IEnumerable<RoomMap> GetRooms(string buildingId, int floorId);
        //void Create(RoomMap room);
        //void Update(RoomMap room);
        //void Delete(RoomMap room);
    }
}
