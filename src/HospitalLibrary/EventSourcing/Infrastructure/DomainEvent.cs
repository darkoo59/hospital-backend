using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EventSourcing.Infrastructure
{
    public abstract class DomainEvent
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }

        public DomainEvent()
        {
            Id = new Guid();
            Time = DateTime.Now;
        }
        public DomainEvent(int aggregateId)
        {
            //Id = aggregateId;
        }
        
    }
}
