using System.Net;
using System.Net.Mail;

namespace Project_UI.Tools
{
    public static class Mail
    {
        public static void SendMail(string body)
        {
            var fromAddress = new MailAddress("gokseldede@gmail.com");
            var toAddress = new MailAddress("gokseldede@gmail.com");

            using (var smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, "xxxxxxxx");
                //abcde kısmı e-posta adresinin şifresi
                using (var message = new MailMessage(fromAddress, toAddress) { Body = body })
                {
                    smtp.Send(message);
                }
            }      
        }

    }
}
