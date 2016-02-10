using System;
using System.Diagnostics;

namespace InmobiliariaGoni.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string body)
        {
            //TODO: Implement Mail Service, for now the debug version will do
            Debug.WriteLine($"Sending mail: To: {to}, Subject: {subject}");
            return true;
        }
    }
}