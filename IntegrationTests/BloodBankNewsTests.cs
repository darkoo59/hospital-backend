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
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            IEnumerable<BankNews> ret = service.GetAll();

            Assert.Equal(ret, data);
        }

        [Fact]
        public void Get_Unchecked_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            List<BankNews> ret = service.GetAllByState(NewsStateEnum.UNCHECKED) as List<BankNews>;

            Assert.Equal(ret[0], data[0]);
        }

        [Fact]
        public void Get_Approved_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            List<BankNews> ret = service.GetAllByState(NewsStateEnum.APPROVED) as List<BankNews>;

            Assert.Equal(ret[0], data[2]);
        }

        [Fact]
        public void Get_Disapproved_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            List<BankNews> ret = service.GetAllByState(NewsStateEnum.DISAPPROVED) as List<BankNews>;

            Assert.Equal(ret[0], data[1]);
        }

        [Fact]
        public void Approve_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            service.ApproveNews(1);

            Assert.Equal(NewsStateEnum.APPROVED, data[0].State);
        }

        [Fact]
        public void Disapprove_News()
        {
            List<BankNews> data = GetNewsData();
            BankNewsService service = new(CreateNewsRepository(data));

            service.ApproveNews(3);

            Assert.Equal(NewsStateEnum.DISAPPROVED, data[2].State);
        }


        #region private

        private static IBankNewsRepository CreateNewsRepository(List<BankNews> data)
        {
            Mock<IBankNewsRepository> studRepo = new Mock<IBankNewsRepository>();
            studRepo.Setup(m => m.GetAll()).Returns(data);

            return studRepo.Object;
        }

        private static List<BankNews> GetNewsData()
        {
            return new()
            {
                new BankNews() { Id = 1, Title = "vijest 1", Content = "sadrzaj vijesti 1", State = NewsStateEnum.UNCHECKED },
                new BankNews() { Id = 2, Title = "vijest 2", Content = "sadrzaj vijesti 2", State = NewsStateEnum.DISAPPROVED },
                new BankNews() { Id = 3, Title = "vijest 3", Content = "sadrzaj vijesti 3", State = NewsStateEnum.APPROVED }
            };
        }

        #endregion
    }
}
