using IntegrationLibrary.Features.UrgentBloodOrder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Repository
{
    public interface IUrgentOrderRepository
    {
        void Create(UrgentOrder urgentOrder);

        List<UrgentOrder> GetInInterval(DateTime dateFrom, DateTime dateTo);
    }
}
