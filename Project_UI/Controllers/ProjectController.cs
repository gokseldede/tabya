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
    public class ProjectController : Controller
    {
        IStandartService<Project> _projectService;

        public ProjectController()
        {
            _projectService = new StandartService<Project>(new EfRepositoryForEntityBase<Project>());
        }

        public ActionResult Index()
        {
            var projects = _projectService.GetAll().ToList();
            return View(projects);
        }

        public ActionResult Detail(int ID)
        {
            var project = _projectService.GetById(ID);
            return View(project);
        }
    }
}