/*using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalTests.Unit
{
    public class ExaminationReportTests
    {
        /*
        [Fact]
        public void Get_All_Examination_Reports()
        {
            List<ExaminationReport> data = GetNewsData();
            //ExaminationReportService service = new(CreateNewsRepository(data));

            //IEnumerable<ExaminationReport> ret = service.GetAll();

            //Assert.Equal(ret, data);
           
        }


        [Fact]
        public void Get_Examination_Report_By_Id()
        {
            List<ExaminationReport> data = GetNewsData();
            //ExaminationReportService service = new(CreateNewsRepository(data));

            //ExaminationReport report = service.GetById(1);

            //Assert.Equal(report, data[0]);
        }

        */
        /*[Fact]
        public void Create_Invalid_Examination_Report()
        {
            List<int> symptomIds = new List<int>();
            List<Symptom> symptoms = new List<Symptom>();
            string report = "";
            List<Recipe> recipes = new List<Recipe>();
            int appointmentId = 1;


            Assert.Throws<ArgumentException>(() => new ExaminationReport(symptomIds, symptoms, report, recipes, appointmentId));
        }


        #region private

        private static IExaminationReportRepository CreateNewsRepository(List<ExaminationReport> data)
        {
            Mock<IExaminationReportRepository> studRepo = new();
            studRepo.Setup(m => m.GetAll()).Returns(data);
            studRepo.Setup(m => m.GetById(1)).Returns(data[0]);
            //studRepo.Setup(m => m.GetById(2)).Returns(data[1]);
            //studRepo.Setup(m => m.GetById(3)).Returns(data[2]);

            return studRepo.Object;
        }

        private static List<ExaminationReport> GetNewsData()
        {
            return new()
            {
                new ExaminationReport() { Id = 1, SymptomIds = new List<int> { 1, 2 }, Report = "neki report" },
                new ExaminationReport() { Id = 2, SymptomIds = new List<int> { 1, 2 }, Report = "neki drugi report" },
                new ExaminationReport() { Id = 3, SymptomIds = new List<int> { 1, 2 }, Report = "neki treci report" }
            };
        }

        #endregion
    }
}
*/