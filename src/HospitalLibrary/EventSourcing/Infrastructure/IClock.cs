using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Infrastructure
{
    public interface IClock
    {
        DateTime Time();
    }
}
