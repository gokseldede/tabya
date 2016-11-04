using PagedList;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class ExpertController : Controller
    {
        IExpertService _service;
        public ExpertController()
        {
            _service = new ExpertService(new EfRepositoryForEntityBase<Expert>());
        }
        // GET: Expert
        public ActionResult Index()
        {
            var experts = _service.GetAll().ToList();
            return View(experts);
        }
    }
}