using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.HospitalMap.Model
{
    public class RoomMap
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Number { get; set; }

        [Range(1, 10)]
        public int FloorId { get; set; }
        public string BuildingId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
