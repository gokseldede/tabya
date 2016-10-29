using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad Soyad:" + message.Name);
                body.AppendLine("Email:" + message.Email);
                body.AppendLine("Number" + message.Number);
                Mail.SendMail(body.ToString());

            }
            return View();
        }
    }
}