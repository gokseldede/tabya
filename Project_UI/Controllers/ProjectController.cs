using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using System.Linq;
using System.Web.Mvc;
using Project_BLL.ServiceModels;
using Project_UI.Models;

namespace Project_UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IStandartService<ProjectServiceModel> _projectService;

        public ProjectController()
        {
            _projectService = new ProjectService();
        }

        public ActionResult Index()
        {
            var projects = _projectService.GetAll().ToList();
            return View(projects);
        }

        public ActionResult Detail(int id)
        {
            var project = _projectService.GetActiveRecordById(id);
            if (project == null)
                return RedirectToAction("NotFound", "Home");

            var vm = new ProjectDetailViewModel()
            {
                Name = project.Name,
                Description = project.Description,
                DeliveryDate = project.ProjectDeliveryDate,
                FlatCount = project.FlatCount,
                PriceList = project.PriceList,
                ProjectArea = project.ProjectArea,
                ProjectFirm = project.ProjectFirm,
                ProjectLocation = project.ProjectLocation,
                Video = project.ProjectPromotionVideo,
                ProjectFiles = project.ProjectFileDetails,
                SelectedProperties = project.SelectedProperties.Select(x => x.Value).ToArray(),
                SelectedSecurities = project.SelectedSecurities.Select(x => x.Value).ToArray(),
                SelectedSocialList = project.SelectedProperties.Select(x => x.Value).ToArray(),
                Expert = project.Expert
            };
            return View(vm);
        }
    }
}