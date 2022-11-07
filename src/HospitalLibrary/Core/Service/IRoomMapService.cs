using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public interface IRoomMapService
    {
        IEnumerable<RoomMap> GetAll();
        RoomMap GetById(int id);
        RoomMap GetByNumber(string number);
        IEnumerable<RoomMap> GetRooms(string buildingId, int floorId);
    }
}
