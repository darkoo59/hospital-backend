using HospitalLibrary.Registration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Registration.Service
{
    public interface IEmailSender
    {
        Task SendEmail(MailContent mailContent);
    }
}
