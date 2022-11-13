using IntegrationLibrary.Features.BloodBankNews.Enums;
using IntegrationLibrary.Features.BloodBankNews.Model;
using IntegrationLibrary.Features.BloodBankNews.Repository;
using IntegrationLibrary.Features.BloodBankNews.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace IntegrationTests.BBNewsTests
{
    public class UnitTests
    {
        [Fact]
        public void Get_All_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            IEnumerable<BankNews> ret = service.GetAll();

            Assert.Equal(ret, data);
        }

        [Fact]
        public void Get_New_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            List<BankNews> ret = service.GetAllByState(NewsState.NEW) as List<BankNews>;

            Assert.Equal(ret[0], data[0]);
        }

        [Fact]
        public void Get_Approved_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            List<BankNews> ret = service.GetAllByState(NewsState.APPROVED) as List<BankNews>;

            Assert.Equal(ret[0], data[2]);
        }

        [Fact]
        public void Get_Declined_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            List<BankNews> ret = service.GetAllByState(NewsState.DECLINED) as List<BankNews>;

            Assert.Equal(ret[0], data[1]);
        }

        [Fact]
        public void Approve_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            service.ApproveNews(1);

            Assert.Equal(NewsState.APPROVED, data[0].State);
        }

        [Fact]
        public void Decline_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            service.DeclineNews(3);

            Assert.Equal(NewsState.DECLINED, data[2].State);
        }

        [Fact]
        public void Get_News_By_Id()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            BankNews news = service.GetById(2);

            Assert.Equal(news, data[1]);
        }


        #region private

        private static IBankNewsRepository CreateNewsRepository(List<BankNews> data)
        {
            Mock<IBankNewsRepository> studRepo = new();
            studRepo.Setup(m => m.GetAll()).Returns(data);
            studRepo.Setup(m => m.GetById(1)).Returns(data[0]);
            studRepo.Setup(m => m.GetById(2)).Returns(data[1]);
            studRepo.Setup(m => m.GetById(3)).Returns(data[2]);

            return studRepo.Object;
        }

        private static List<BankNews> GetNewsData()
        {
            return new()
            {
                new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1", State = NewsState.NEW },
                new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2", State = NewsState.DECLINED },
                new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3", State = NewsState.APPROVED }
            };
        }

        #endregion
    }
}
