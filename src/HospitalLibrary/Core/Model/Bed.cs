using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Bed
    {
        public int BedId { get; set; }
        public string Label { get; set; }
        public bool IsAvailable { get; set; }

    }
}
