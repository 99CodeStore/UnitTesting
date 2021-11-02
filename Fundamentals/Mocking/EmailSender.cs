using System.Net;
using System.Net.Mail;
using System.Text;

namespace Fundamentals.Mocking
{
    public class EmailSender : IEmailSender
    {
        public void EmailFile(string emailAddress, string emailBody, string statementFilename, string v)
        {
            var client = new SmtpClient(SystemSettingsHelper.EmailSmtpHost)
            {
                Port = SystemSettingsHelper.EmailPort,
                Credentials = new NetworkCredential(
                    SystemSettingsHelper.EmailUsername,
                    SystemSettingsHelper.EmailPassword)
            };

            var from = new MailAddress(SystemSettingsHelper.EmailFromEmail, SystemSettingsHelper.EmailUsername, Encoding.UTF8);

            var to = new MailAddress(emailAddress);

            var message = new MailMessage(from, to);
        }
    }

    public static class SystemSettingsHelper
    {
        public static string EmailSmtpHost { get; set; }
        public static int EmailPort { get; set; }
        public static string EmailUsername { get; set; }
        public static string EmailPassword { get; set; }
        public static string EmailFromEmail { get; set; }
        static SystemSettingsHelper()
        {

        }
    }
}
