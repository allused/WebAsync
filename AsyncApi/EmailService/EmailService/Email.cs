using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using EmailService.Logging;
using System.Diagnostics;

namespace EmailService.EmailService
{
    public class Email : IEmail
    {
        private string adminEmail;
        private string adminPassword;
        private SmtpClient smtpClient;

        public Email()
        {

        }
        public async void SetupService(string email, string password)
        {
            adminPassword = password;
            adminEmail = email;

            try
            {
                smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(email, password);
            }
            catch (Exception ex)
            {
                Logger.GetNewEventLog().WriteEntry("Email service setup failed : " + ex, EventLogEntryType.Error, 2, (short)Logger.LogTypes.EmailServiceSetupFailed);
            }
        }

        public async void  SendMail(string recieverEmail, string subject, string bodyText)
        {
            try
            {
                MailMessage messageObj = new MailMessage();
                messageObj.To.Add(recieverEmail);
                messageObj.From = new MailAddress(adminEmail);
                messageObj.Subject = subject;
                messageObj.Body = bodyText;

                await smtpClient.SendMailAsync(messageObj);

            }catch (Exception ex)
            {
                Logger.GetNewEventLog().WriteEntry("Email service setup failed : " + ex, EventLogEntryType.Error, 1, (short)Logger.LogTypes.EmailSendingFailed);
            }
        }
    }
}
