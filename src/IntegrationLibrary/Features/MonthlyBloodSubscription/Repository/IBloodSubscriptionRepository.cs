using IntegrationLibrary.Features.MonthlyBloodSubscription.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.Repository
{
    public interface IBloodSubscriptionRepository
    {
        IEnumerable<BloodSubscription> GetAll();
        BloodSubscription GetById(int id);
        BloodSubscription GetByBbId(int id);
        void Create(BloodSubscription monthlyBloodSubscription);
        void Remove(BloodSubscription bloodSubscription);
    }
}
