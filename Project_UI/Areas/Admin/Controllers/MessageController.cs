using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class MessageController : BaseController
    {
        // GET: Admin/Message
        // GET: Admin/Message
        public ActionResult Index()
        {
            List<Message> _messages = Database.Messages.Where(x => x.IsDelete == false).ToList() ;
            return View(_messages);
        }

        public ActionResult Detail(int ID)
        {
            return View(Database.Messages.Find(ID));
        }
        [HttpPost]
        public ActionResult Detail(Message _message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
           // mail.To = _message.EMail;
            //mail.From = "you@yourcompany.com";
            mail.Subject = _message.ReplyTitle;
            mail.Body = _message.Reply;
            client.Send(mail);

            return RedirectToAction("Index", "Home");
        }
    }
}