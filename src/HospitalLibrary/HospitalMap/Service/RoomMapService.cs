using HospitalLibrary.HospitalMap.Model;
using HospitalLibrary.HospitalMap.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.HospitalMap.Service
{
    public class RoomMapService : IRoomMapService
    {
        private readonly IRoomMapRepository _roomMapRepository;

        public RoomMapService(IRoomMapRepository roomMapRepository)
        {
            _roomMapRepository = roomMapRepository;
        }
        public IEnumerable<RoomMap> GetAll()
        {
            return _roomMapRepository.GetAll();
        }

        public RoomMap GetById(int id)
        {
            return _roomMapRepository.GetById(id);
        }

        public RoomMap GetByNumber(string number)
        {
            return _roomMapRepository.GetByNumber(number);
        }

        public IEnumerable<RoomMap> GetRooms(string buildingId, int floorId)
        {
            return _roomMapRepository.GetRooms(buildingId, floorId);
        }
    }
}
