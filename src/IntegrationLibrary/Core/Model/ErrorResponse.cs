using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string StackTrace { get; set; }

        public ErrorResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            MethodName = new StackTrace(ex).GetFrame(0).GetMethod().Name;
            StackTrace = ex.ToString();
        }
    }
}
