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
            string from = "mai_email@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = true;
            message.Subject = "Ordine Ricambio";
            message.Body = @" TEST";
            SmtpClient client = new SmtpClient();

            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("mia_email@gmail.com", "password");
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
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
