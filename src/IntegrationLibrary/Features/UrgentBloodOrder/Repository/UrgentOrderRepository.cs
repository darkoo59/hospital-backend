using IntegrationLibrary.Features.UrgentBloodOrder.Model;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Repository
{
    public class UrgentOrderRepository : IUrgentOrderRepository
    {
        private readonly IntegrationDbContext _context;

        public UrgentOrderRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public void Create(UrgentOrder urgentOrder)
        {
            _context.UrgentOrders.Add(urgentOrder);
            _context.SaveChanges();
        }

        public List<UrgentOrder> GetInInterval(DateTime dateFrom, DateTime dateTo)
        {
            List<UrgentOrder> ret = new List<UrgentOrder>();

            foreach(UrgentOrder order in _context.UrgentOrders.ToList())
            {
                if(order.Date >= dateFrom && order.Date <= dateTo)
                {
                    ret.Add(order);
                }
            }
            return ret;
        }
    }
}
