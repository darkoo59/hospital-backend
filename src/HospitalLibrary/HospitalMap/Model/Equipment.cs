using HospitalLibrary.HospitalMap.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.HospitalMap.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
