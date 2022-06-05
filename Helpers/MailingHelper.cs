using broker.Models;
using System.Net;
using System.Net.Mail;

namespace broker.Helpers
{
    public class MailingHelper
    {
        public static void SendMail(string to, string messageString)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(SmtpSettings.login);
                message.To.Add(new MailAddress(to));
                message.Subject = "Aviso, você foi avisado.";
                message.IsBodyHtml = true;
                message.Body = messageString;

                SmtpClient smtp = GetSmtpClient();
                smtp.Send(message);
            } catch(Exception e )
            {
                Console.WriteLine("Error on SendMail");
                Console.WriteLine(e.Message);
            }
        }

        private static SmtpClient GetSmtpClient()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Port = SmtpSettings.port;
            smtp.Host = SmtpSettings.hostname;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(SmtpSettings.login, SmtpSettings.password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            return smtp;
        }
    }
}
