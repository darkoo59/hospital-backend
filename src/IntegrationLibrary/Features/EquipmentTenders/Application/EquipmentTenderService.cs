using IntegrationLibrary.Features.EquipmentTenders.Application.Abstract;
using IntegrationLibrary.Features.EquipmentTenders.Infrastructure.Abstract;

namespace IntegrationLibrary.Features.EquipmentTenders.Application
{
    public class TenderEquipmentService : IEquipmentTenderService
    {
        private IEquipmentTenderRepository _repository;
        public TenderEquipmentService(IEquipmentTenderRepository repository)
        {
            _repository = repository;
        }


    }
}
