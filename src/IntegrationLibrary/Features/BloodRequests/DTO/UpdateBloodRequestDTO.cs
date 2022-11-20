

namespace IntegrationLibrary.Features.BloodRequests.DTO
{
    public class UpdateBloodRequestDTO
    {
        public int Id { get; set; }
        public string NewReason { get; set; }
        public double NewQuantity{ get; set; }
    }
}
