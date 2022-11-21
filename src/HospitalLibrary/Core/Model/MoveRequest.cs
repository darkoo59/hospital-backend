using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Model
{
    public class MoveRequest
    {
        [Required]
        public int fromRoomId { get; set; }
        public int toRoomId { get; set; }
        public string equipment { get; set; }
        public int quantity { get; set; }
        




    }
}
