using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodBankNews.Repository;
using IntegrationLibrary.Features.BloodBankNews.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace IntegrationTests
{
    public class BloodBankNewsTests
    {
        [Fact]
        public void Get_All_News()
        {
            List<BankNews> news = new()
            {
                new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1" },
                new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2" },
                new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3" }
            };

            var studRepo = new Mock<IBankNewsRepository>();
            studRepo.Setup(m => m.GetAll()).Returns(news);
            BankNewsService service = new(studRepo.Object);

            IEnumerable<BankNews> ret = service.GetAll();

            Assert.Equal(ret, news);
        }
    }
}
