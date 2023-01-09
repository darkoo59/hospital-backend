using Gehtsoft.PDFFlow.Builder;
using Gehtsoft.PDFFlow.Models.Enumerations;
using Grpc.Core;
using IntegrationLibrary.Features.Blood.Enums;
using IntegrationLibrary.Features.BloodBank.Service;
using IntegrationLibrary.Features.UrgentBloodOrder.DTO;
using IntegrationLibrary.Features.UrgentBloodOrder.Model;
using IntegrationLibrary.Features.UrgentBloodOrder.Repository;
using IntegrationLibrary.HospitalService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UrgentOrderService;

namespace IntegrationLibrary.Features.UrgentBloodOrder.Service
{
    public class UrgentBloodOrderService : IUrgentBloodOrderService
    {
        private readonly IHospitalService _hospitalService;
        private readonly IUrgentOrderRepository _urgentRepository;
        private readonly IUserService _userService;
        private Channel _channel { get; set; }
        public UrgentBloodOrderService(IHospitalService hospitalRepository, IUrgentOrderRepository urgentRepository, IUserService userService)
        {
            this._hospitalService = hospitalRepository;
            this._urgentRepository = urgentRepository;
            this._userService = userService;
        }

        public UrgentResponse InvokeUrgentOrder(int bloodType, float quantity, string server)
        {
            //Int32 port = Int32.Parse(server.Substring(server.Length - 4)); Kada bude integrisano i za ostale isa projekte

            _channel = new Channel("localhost", 6565, ChannelCredentials.Insecure);

            UrgentOrder urgentOrder = new UrgentOrder(ParseIntToBloodType(bloodType), (double)quantity, findAppNameByServer(server));

            UrgentOrderServiceClient client = new UrgentOrderServiceClient(_channel);
            UrgentRequest request = new UrgentRequest();
            request.BloodType = bloodType;
            request.Quantity = quantity;

            UrgentResponse response = client.InvokeUrgentOrder(request);
            
            if (response.HasEnough)
            {
                _hospitalService.UpdateBloodQuantity(bloodType, quantity);
                _urgentRepository.Create(urgentOrder);
                Console.WriteLine("New blood has arrived.");
            } else
            {
                Console.WriteLine("No new blood has arrived.");
            }
            return response;
        }

   

        public BloodType ParseIntToBloodType(int number)
        {
            switch (number)
            {
                case 0: return BloodType.A_PLUS;
                case 1: return BloodType.A_MINUS;
                case 2: return BloodType.B_PLUS;
                case 3: return BloodType.B_MINUS;
                case 4: return BloodType.O_PLUS;
                case 5: return BloodType.O_MINUS;
                case 6: return BloodType.AB_PLUS;
                default: return BloodType.AB_MINUS;
            }
        }

        public String findAppNameByServer(String server)
        {
            return _userService.GetAppNameByServer(server);
        }

        public String CreateUrgentOrderReport(DateTime dateFrom, DateTime dateTo)
        {
            List<UrgentOrder> urgentOrders = _urgentRepository.GetInInterval(dateFrom, dateTo)
                .OrderBy(x => (int) x.BloodType).ToList();
            double totalAPlus = 0, totalAMinus = 0, totalBPlus = 0, totalBMinus = 0, totalABPlus = 0, totalABMinus = 0, totalOPlus = 0, totalOMinus = 0;

            String pdfName = "Urgent_order_report" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString()
                + "-" + DateTime.Now.Year.ToString() + "-" +
                DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".pdf";
            var folderPath = Environment.CurrentDirectory + "/PDFs";
            var filePath = Path.Combine(folderPath, pdfName);

            var myStream = new FileStream(filePath, FileMode.Create);

            DocumentBuilder builder = DocumentBuilder.New();
            var section = builder.AddSection();
            section.AddParagraph("Urgent order report for the time period of " + dateFrom.ToString("dd/mm/yyyy") + " to " + dateTo.ToString("dd/mm/yyyy")).SetFontSize(20).SetAlignment(HorizontalAlignment.Center).ToDocument();

            foreach(UrgentOrder order in urgentOrders)
            {
                section.AddParagraph("Blood type:" + order.BloodType.ToString() + "  |  Quantity: " + order.Quantity + "ml  |  Date: " + order.Date.ToShortDateString() +  "  |  Blood bank: " + order.BloodBankName).SetFontSize(16).SetMarginTop(8).ToDocument();
                switch (order.BloodType)
                {
                    case BloodType.A_PLUS:
                        {
                            totalAPlus += order.Quantity;
                            break;
                        }
                    case BloodType.A_MINUS:
                        {
                            totalAMinus += order.Quantity;
                            break;
                        }
                    case BloodType.B_PLUS:
                        {
                            totalBPlus += order.Quantity;
                            break;
                        }
                    case BloodType.B_MINUS:
                        {
                            totalBMinus += order.Quantity;
                            break;
                        }
                    case BloodType.AB_MINUS:
                        {
                            totalABMinus += order.Quantity;
                            break;
                        }
                    case BloodType.AB_PLUS:
                        {
                            totalABPlus += order.Quantity;
                            break;
                        }
                    case BloodType.O_MINUS:
                        {
                            totalOMinus += order.Quantity;
                            break;
                        }
                    case BloodType.O_PLUS:
                        {
                            totalOPlus += order.Quantity;
                            break;
                        }
                    default:
                        break;
                }
            }
            section.AddLine().ToDocument();
            section.AddParagraph("Total blood of type A+ : " + totalAPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type A- : " + totalAMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type B+ : " + totalBPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type B- : " + totalBMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type AB+ : " + totalABPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type AB- : " + totalABMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type O+ : " + totalOPlus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            section.AddParagraph("Total blood of type O- : " + totalOMinus + "ml.").SetFontSize(14).SetMarginTop(10).ToDocument();
            builder.Build(myStream);
            myStream.Close();
            return filePath;
        }

    }
}
