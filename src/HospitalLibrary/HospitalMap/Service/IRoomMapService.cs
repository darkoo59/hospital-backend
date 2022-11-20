using HospitalLibrary.HospitalMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.HospitalMap.Service
{
    public interface IRoomMapService
    {
        IEnumerable<RoomMap> GetAll();
        RoomMap GetById(int id);
        RoomMap GetByNumber(string number);
        IEnumerable<RoomMap> GetRooms(string buildingId, int floorId);
    }
}
