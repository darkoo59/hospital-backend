using IntegrationLibrary.Features.Blood.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.MonthlyBloodSubscription.Mapper
{
    public class ReceivedBloodTypeMapper
    {
        public string ReceivedTypeToBloodType(string type)
        {
            switch (type)
            {
                case "APositive":
                    return "A+";
                case "ANegative":
                    return "A-";
                case "BPositive":
                    return "B+";
                case "BNegative":
                    return "B-";
                case "OPositive":
                    return "O+";
                case "ONegative":
                    return "O-";
                case "ABPositive":
                    return "AB+";
                default:
                    return "AB-";

            }
        }
    }
}
