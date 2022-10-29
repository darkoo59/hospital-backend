using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public Boolean Privatisation { get; set; }
        public string Textt { get; set; }
        public string User { get; set; }
        public string Date { get; set; }
        public Boolean IsDisplayedPublic { get; set; }
    }
}
