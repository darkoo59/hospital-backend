using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.Blood.Service;
using IntegrationLibrary.Features.BloodBank;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.BloodRequests.Enums;
using IntegrationLibrary.Features.MonthlyBloodSubscription.DTO;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Mapper;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Model;
using IntegrationLibrary.Features.MonthlyBloodSubscription.Repository;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.Service
{
    public class BloodSubscriptionService : IBloodSubscriptionService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly IBloodSubscriptionRepository _bloodSubscriptionRepository;
        private readonly IUserService _userService;
        private readonly ReceivedBloodTypeMapper _bloodTypeMapper;
        public BloodSubscriptionService(IBloodSubscriptionRepository subscriptionRepository, IUserService userService)
        {
            _bloodSubscriptionRepository = subscriptionRepository;
            _userService = userService;
            _bloodTypeMapper = new ReceivedBloodTypeMapper();
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
            SendSubscriptionToBloodBank(newBloodSubscription);
        }

        public async void Unsubscribe(int bloodBankId)
        {
            List<BloodSubscription> allSubscribed = _bloodSubscriptionRepository.GetAll().ToList();
            foreach (BloodSubscription subscription in allSubscribed)
            {
                if (subscription.BloodBankId == bloodBankId)
                {
                    _bloodSubscriptionRepository.Remove(subscription);
                    User bloodBank = _userService.GetById(bloodBankId);
                    var url = "http://"+bloodBank.Server+"/api/subscribed-hospital/unsubscribe";
                    await _httpClient.PostAsJsonAsync(url, bloodBank.Email);
                    break;
                }
            }
        }

        private async void SendSubscriptionToBloodBank(BloodSubscription newBloodSubscription)
        {
            User bloodBank = _userService.GetById(newBloodSubscription.BloodBankId);
            SendDetailsToBbDTO subscriptionDTO = new SendDetailsToBbDTO()
            {
                hospitalName = bloodBank.AppName,
                email = bloodBank.Email,
                server = "http://" + bloodBank.Server,
                bloodType = ConvertBloodTypeForBb(newBloodSubscription.BloodType),
                quantity = newBloodSubscription.QuantityInLiters 
            };
            if (bloodBank.Server.Equals("localhost:6555"))
            {
                var url = "http://" + bloodBank.Server + "/api/subscribed-hospital/subscribe";
                await _httpClient.PostAsJsonAsync(url,subscriptionDTO);
            }
        }

        private string ConvertBloodTypeForBb(BloodType type)
        {
            switch (type)
            {
                case BloodType.A_PLUS:
                    return "APositive";
                case BloodType.A_MINUS:
                    return "ANegative";
                case BloodType.B_PLUS:
                    return "BPositive";
                case BloodType.B_MINUS:
                    return "BNegative";
                case BloodType.O_PLUS:
                    return "OPositive";
                case BloodType.O_MINUS:
                    return "ONegative";
                case BloodType.AB_PLUS:
                    return "ABPositive";
                case BloodType.AB_MINUS:
                    return "ABNegative";
                default:
                    return "";
            }
        }

        public async void ReceiveBlood(ReceivedBloodDTO bloodDTO)
        {
            SendBloodToHospitalDTO bloodToSend = new SendBloodToHospitalDTO()
            {
                BloodType = _bloodTypeMapper.ReceivedTypeToBloodType(bloodDTO.BloodType),
                QuantityInLiters = bloodDTO.quantity
            };
                var url = "http://localhost:16177/api/Bloods/receive-blood";
                await _httpClient.PostAsJsonAsync(url, bloodToSend);
        }
    }
}
