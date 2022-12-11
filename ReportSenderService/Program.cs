using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ReportSenderService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //HttpClient _httpClient = new HttpClient();

            ReportService reportService = new ReportService();
            EquipmentMoveService equipmentMoveService = new EquipmentMoveService();

            //reportService.ManualStart();

            ServiceBase.Run(new ServiceBase[]
            {
                reportService,
                equipmentMoveService
            });

            //while (true) ;
        }
    }
}
