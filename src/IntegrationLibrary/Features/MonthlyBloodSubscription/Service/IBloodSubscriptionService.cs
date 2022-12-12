using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.Service
{
    public interface IBloodSubscriptionService
    {
        IEnumerable<BloodSubscription> GetAll();
        IEnumerable<UnsubscribedBbDTO> GetAllUnsubscribed();
        IEnumerable<SubscribedBbDTO> GetAllSubscribed();
        void Subscribe(CreateSubscriptionDTO newSubscriptionDTO);
        void Unsubscribe(int bloodBankId);
        void ReceiveBlood(ReceivedBloodDTO bloodDTO);
    }
}
