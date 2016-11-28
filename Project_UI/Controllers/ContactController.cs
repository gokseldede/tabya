using System.Text;
using System.Web.Mvc;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_Entity;
using Project_UI.Models;

namespace Project_UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IStandartService<Contact> _contanctService;

        public ContactController()
        {
            _contanctService = new ContanctService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContanctViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contanctService.Create(new Contact() { Email = model.EMail, Name = model.Name, Number = model.PhoneNumber });

                var body = new StringBuilder();
                body.AppendLine("Ad Soyad:" + model.Name);
                body.AppendLine("Email:" + model.EMail);
                body.AppendLine("Number" + model.PhoneNumber);
                //Mail.SendMail(body.ToString());

            }
            return RedirectToAction("Index","Home");
        }
    }
}