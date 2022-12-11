using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodBank;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Model;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.Service
{
    public class BloodSubscriptionService : IBloodSubscriptionService
    {
        private readonly IBloodSubscriptionRepository _bloodSubscriptionRepository;
        private readonly IUserService _userService;
        public BloodSubscriptionService(IBloodSubscriptionRepository subscriptionRepository, IUserService userService)
        {
            _bloodSubscriptionRepository = subscriptionRepository;
            _userService = userService;
        }
        public IEnumerable<BloodSubscription> GetAll()
        {
            return _bloodSubscriptionRepository.GetAll();
        }

        public IEnumerable<SubscribedBbDTO> GetAllSubscribed()
        {
            List<BloodSubscription> allSubscribed = _bloodSubscriptionRepository.GetAll().ToList();
            List<SubscribedBbDTO> allSubscribedDto = new List<SubscribedBbDTO>();
            foreach (BloodSubscription subscription in allSubscribed)
            {
                allSubscribedDto.Add(new SubscribedBbDTO()
                {
                    Id = subscription.Id,
                    AppName = _userService.GetById(subscription.BloodBankId).AppName,
                    BloodBankId = subscription.BloodBankId,
                    BloodType = subscription.BloodType.ToString(),
                    QuantityInLiters = subscription.QuantityInLiters,
                    StartDate = subscription.StartDate
                });
            }
            return allSubscribedDto.AsEnumerable();
        }

        public IEnumerable<UnsubscribedBbDTO> GetAllUnsubscribed()
        {
            List<UnsubscribedBbDTO> unsubscribedBbToReturn = new List<UnsubscribedBbDTO>();
            foreach (User bloodBank in _userService.GetAll())
            {
                if (_bloodSubscriptionRepository.GetByBbId(bloodBank.Id) == null)
                {
                    unsubscribedBbToReturn.Add(new UnsubscribedBbDTO()
                    {
                        Id = bloodBank.Id,
                        AppName =
                        bloodBank.AppName
                    });
                }
            }
            return unsubscribedBbToReturn.AsEnumerable();
        }

        public void Subscribe(CreateSubscriptionDTO newSubscriptionDTO)
        {
            BloodSubscription newBloodSubscription = new()
            {
                BloodBankId = newSubscriptionDTO.bloodBankId,
                StartDate = DateTime.Now,
                BloodType = (BloodType)newSubscriptionDTO.BloodType,
                QuantityInLiters = newSubscriptionDTO.QuantityInLiters
            };
            _bloodSubscriptionRepository.Create(newBloodSubscription);
        }

        public void Unsubscribe(int bloodBankId)
        {
            List<BloodSubscription> allSubscribed = _bloodSubscriptionRepository.GetAll().ToList();
            foreach (BloodSubscription subscription in allSubscribed)
            {
                if (subscription.BloodBankId == bloodBankId)
                {
                    _bloodSubscriptionRepository.Remove(subscription);
                    break;
                }
            }
        }
    }
}
