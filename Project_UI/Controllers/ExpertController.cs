using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;
using System.Linq;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class ExpertController : Controller
    {
        private readonly IExpertService _service;
        public ExpertController()
        {
            _service = new ExpertService(new EfRepositoryForEntityBase<Expert>());
        }
        // GET: Expert
        public ActionResult Index()
        {
            var experts = _service.Get(x => x.IsActive && x.IsDelete == false).ToList();
            return View(experts);
        }
    }
}