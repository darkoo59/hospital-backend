using HospitalLibrary.HospitalMap.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HospitalLibrary.Core.Model
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Number { get; set; }

        [Range(1, 10)]
        public int FloorId { get; set; }
        public string BuildingId { get; set; }
        public string Description { get; set; }
        public RoomType Type { get; set; }
        //public List<Equipment> EquipmentList { get; set;}
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Bed> Beds { get; set; }

    }
}
