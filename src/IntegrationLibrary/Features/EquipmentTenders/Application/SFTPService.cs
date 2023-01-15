using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace IntegrationLibrary.Features.EquipmentTenders.Application
{
    public class SFTPService
    {
        public static void UploadPDF(string localFilePath, string remoteFilePath)
        {
            // Connect to the SFTP server
            var host = "127.0.0.1";
            var username = "tester";
            var password = "password";
            var sftpClient = new SftpClient(host, 2222, username, password);
            sftpClient.Connect();

            // Open the file to be uploaded
            using (var fileStream = new FileStream(localFilePath, FileMode.Open))
            {
                // Upload the file to the SFTP server
                sftpClient.UploadFile(fileStream, remoteFilePath);
            }

            // Disconnect from the SFTP server
            sftpClient.Disconnect();
        }
    }
}
