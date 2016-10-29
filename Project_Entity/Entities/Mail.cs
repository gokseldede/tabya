using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public static class Mail
    {
        public static void SendMail(string body)
        {
            var fromAddress = new MailAddress("gokseldede@gmail.com");
            var toAddress = new MailAddress("gokseldede@gmail.com");

            using (var smtp=new SmtpClient {

                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "11021993gfb")
                //abcde kısmı e-posta adresinin şifresi

            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Body = body })
                {
                    smtp.Send(message);
                }
            }
        }

    }
    public class Newsletter:EntityBase
    {
        public string Email { get; set; }
    }
}
