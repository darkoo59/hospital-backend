using System;

namespace IntegrationLibrary.Features.EquipmentTenders.Domain
{
    public class TenderApplication
    {
        public int Id { get; set; }
        public int Notes { get; set; }
        public int Email { get; set; }
        public TenderApplication() { }
        public TenderApplication(int notes, int email)
        {
            Notes = notes;
            Email = email;
        }
    }

    public class InvalidDataException : Exception
    {
        public InvalidDataException() : base("Provided data was invalid") { }
    }
}
