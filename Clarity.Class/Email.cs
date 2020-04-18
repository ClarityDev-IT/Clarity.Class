using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clarity.Email
{
    [Guid("59EC011E-76BA-4634-8E5D-044EA8FD2C56")]
    [ComVisible(true)]

    [ClassInterface(ClassInterfaceType.AutoDual)]

    [ProgId("Clarity.Email")]
    public class Email
    {
        public void SendMail(string from, string to, string smtpServer, int port, string user, string password, string subject, string body, string[] attachments)
        {
            SmtpMail oMail = new SmtpMail("ES-D1508812687-00707-17A9UECEB7DV192D-8DB3B1U3TUA8UEFU");
            SmtpClient oSmtp = new SmtpClient();

            // Set sender email address, please change it to yours
            oMail.From = from;

            // Set recipient email address, please change it to yours
            oMail.To = to;

            // Set email subject
            oMail.Subject = subject;

            // Set email body
            oMail.TextBody = body;

            //AddAttachment
            foreach (string file in attachments)
            {
                try
                {
                    oMail.AddAttachment(file);
                }
                catch (Exception ex)
                {
                    // process exception here
                    continue;
                }
            }

            // Your SMTP server address
            SmtpServer oServer = new SmtpServer(smtpServer);

            // User and password for ESMTP authentication, if your server doesn't require
            // User authentication, please remove the following codes.
            if (user != null)
            {
                oServer.User = user;
                oServer.Password = password;
            }

            // Set 25 or 587 port.
            oServer.Port = port;

            // detect TLS connection automatically
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
            try
            {
                Console.WriteLine("start to send email ...");
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");

            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);

            }
        }
    }
}
