using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Features.Blood.DTO;
using IntegrationLibrary.Features.BloodBank.Model;
using IntegrationLibrary.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationLibrary.Features.BloodBank
{
    public class BloodBankService : IBloodBankService
    {
        private readonly MailSettings _mailSettings;
        private static readonly HttpClient _httpClient = new();

        public BloodBankService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public BloodBankService()
        {
        }

        public async Task SendEmail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailContent.ToEmail));
            email.Subject = mailContent.Subject;
            var builder = new BodyBuilder();
            if (mailContent.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailContent.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task<string> GenerateApiKey(User user)
        {
            HttpContent content = new StringContent(user.Email);
            HttpResponseMessage response = await _httpClient.PostAsync("http://" + user.Server + "/api/key/create", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error while communicating with ISA server");
            }

            string ret = await response.Content.ReadAsStringAsync();
            return ret;
        }

        public async Task<string> ConfirmTender(User user, ICollection<BloodDTO> data)
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(data));
            HttpResponseMessage response = await _httpClient.PatchAsync("http://" + user.Server + "/api/blood/tender/confirm", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error while communicating with ISA server");
            }
            
            string ret = await response.Content.ReadAsStringAsync();
            return ret;
        }
    }
}
