using System;
using IntegrationLibrary.Features.BloodBankNews.Enums;

namespace IntegrationLibrary.Features.BloodBankNews.Model
{
    public class BankNews
    {
        public int Id { set; get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public NewsState State { get; set; }

        public class BankNewsException : Exception
        {
            public BankNewsException(string message) : base(message) { }
        }
    }
}