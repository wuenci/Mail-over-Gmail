using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendMailWithGmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string to = "to_email@msn.com";
            string from = "from_email@gmail.com";
            string password = "password";

            string host = "smtp.gmail.com";
            int port = 587;

            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;
            message.Subject = "Messaggio di rova";
            message.Body = @"Contenuto di prova";
            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(from, password);
            client.Host = host;
            client.EnableSsl = true;
            client.Port = port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
                Console.WriteLine("Il messaggio è stato inviato");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                      ex.ToString());
            }
        }
    }
}
