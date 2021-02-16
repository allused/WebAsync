using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.EmailService
{
    public interface IEmail
    {
        void SetupService(string email, string password);
        void SendMail(string recieverEmail, string subject, string bodyText);
    }
}
