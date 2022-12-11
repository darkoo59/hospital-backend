using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Core.Model
{
    public class MoveRequest
    {
        [Required][Key]
        public int id { get; set; }
        public string type { get; set; } //EquipmentMove, RenovationSplit, RenovationMerge
        public int fromRoomId { get; set; }
        public int toRoomId { get; set; }
        public string equipment { get; set; }
        public int quantity { get; set; }
        public DateTime wantedStartTime { get; set; }
        public DateTime wantedEndTime { get; set; }
        public DateTime chosenStartTime { get; set; }
        public TimeSpan duration { get; set; }
    }
}