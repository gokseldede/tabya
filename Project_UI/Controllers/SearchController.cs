using System.Linq;
using System.Web.Mvc;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
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

        public ActionResult Query(string search, string order = null)
        {
            var result = _service.GetAdvertisements(search);

            switch (order)
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

            var vm = new QueryViewModel()
            {
                List=result,
                Order = order,
                Query = search
            };
            return View(vm);
        }
    }
}