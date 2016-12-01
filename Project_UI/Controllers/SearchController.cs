using System.Linq;
using System.Web.Mvc;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;
using Project_UI.Models;

namespace Project_UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly IWebSiteService _service;

        public SearchController()
        {
            _service = new WebSiteService();
        }

        public ActionResult Query(QueryViewModel vm)
        {
            var serviceModel = new QueryServiceModel()
            {
                AdType = vm.AdType,
                IlceId = vm.IlceId,
                Query = vm.Query,
                Boyut = vm.Boyut,
                IlId = vm.IlId,
                Oda = vm.Oda
            };
            var result = _service.GetAdvertisements(serviceModel);

            switch (vm.Order)
            {
                case "yenideneskiye":
                    result = result.OrderByDescending(x => x.Id).ToList();
                    break;
                case "eskidenyeniye":
                    result = result.OrderBy(x => x.Id).ToList();
                    break;
                case "ucuzdanpahaliya":
                    result = result.OrderBy(x => x.Price).ToList();
                    break;
                case "pahalidanucuza":
                    result = result.OrderByDescending(x => x.Price).ToList();
                    break;
            }

            vm.List = result;
            return View(vm);
        }
    }
}