using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int FloorId { get; set; }
        public string BuildingId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<BedDTO> Beds { get; set; }
    }
}
