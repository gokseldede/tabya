using System.Data;
using System.Linq;
using System.Web.Mvc;
using Project_Entity;
using PagedList;
using Project_BLL.Implementation;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;
using Project_UI.Models;

namespace Project_UI.Controllers
{
    public class AdDetailController : Controller
    {
        private readonly IAdService _adService;
        private readonly IStandartService<WorkplaceServiceModel> _workService;
        private readonly IStandartService<LandServiceModel> _landService;
        private readonly IStandartService<BuildingServiceModel> _binaService;
        private readonly IWebSiteService _webSiteService;
        public AdDetailController()
        {
            _adService = new AdService();
            _workService = new WorkPlaceService();
            _webSiteService = new WebSiteService();
            _landService = new LandService();
            _binaService = new BuildingService();

        }

        // GET: AdDetail
        public ActionResult Index()
        {
            var list = _webSiteService.GetAdvertisements(new QueryServiceModel());
            return View(list);
        }

        // GET: AdDetail/Details/5
        public ActionResult Details(int id)
        {
            var adDetail = _adService.GetActiveRecordById(id);
            if (adDetail == null)
                return RedirectToAction("NotFound", "Home");

            var vm = new AdDetailDetailViewModel()
            {
                Id = adDetail.Id,
                Name = adDetail.Name,
                ThumbPath = adDetail.ThumbPath,
                CreatedDateTime = adDetail.CreatedDateTime,
                Description = adDetail.Description,
                Price = adDetail.Price,
                UpdatedDateTime = adDetail.UpdatedDateTime,
                Size = adDetail.Size,
                BAge = adDetail.BAge,
                BathroomCount = adDetail.BathroomCount,
                Dues = adDetail.Dues,
                EsyaStatus = adDetail.Esya,
                Isinma = adDetail.Isinma,
                Status = adDetail.Status,
                FlatFloor = adDetail.FlatFloor,
                FloorCount = adDetail.FloorCount,
                Kimden = adDetail.Kimden,
                KrediDurumu = adDetail.Kredi,
                KullanimStatus = adDetail.Kullanim,
                Kur = adDetail.Kur,
                RoomCount = adDetail.RoomCount,
                SiteStatus = adDetail.Site,
                FileDetails = adDetail.FileDetails,
                Il = adDetail.Il,
                Ilce = adDetail.Ilce,
                Semt = adDetail.Semt,
                Expert = adDetail.Expert,
                SelectedProperties = adDetail.SelectedProperties.Select(x => x.Value).ToArray(),
                SelectedSecurities = adDetail.SelectedSecurities.Select(x => x.Value).ToArray(),
                SelectedSocialList = adDetail.SelectedSocialApps.Select(x => x.Value).ToArray()
            };
            return View(vm);
        }
        public ActionResult LandDetail(int id)
        {
            var adDetail = _landService.GetActiveRecordById(id);
            if (adDetail == null)
                return RedirectToAction("NotFound", "Home");

            var vm = new AdDetailDetailViewModel()
            {
                Id = adDetail.Id,
                Name = adDetail.Name,
                ThumbPath = adDetail.ThumbPath,
                CreatedDateTime = adDetail.CreatedDateTime,
                Description = adDetail.Description,
                Price = adDetail.Price,
                UpdatedDateTime = adDetail.UpdatedDateTime,
                Size = adDetail.Size,
                Status = adDetail.Status,
                Kimden = adDetail.Kimden,
                KrediDurumu = adDetail.Kredi,
                Kur = adDetail.Kur,
                Expert = adDetail.Expert,
                FileDetails = adDetail.FileDetails,
                AdaNo = adDetail.AdaNo,
                Imar = adDetail.Imar,
                Gabari = adDetail.Gabari,
                ImarStatus = adDetail.Imar,
                KatKarsiligi = adDetail.KatKarsiligi,
                PaftaNo = adDetail.PaftaNo,
                ParselNo = adDetail.ParselNo,
                SizePrice = adDetail.PriceForM2,
                Tapu = adDetail.TapuDurumu,
                Kaks = adDetail.Emsal,
                Il = adDetail.Il,
                Ilce = adDetail.Ilce,
                Semt = adDetail.Semt,
            };
            return View(vm);
        }
        public ActionResult WorkDetail(int id)
        {
            var adDetail = _workService.GetActiveRecordById(id);
            if (adDetail == null)
                return RedirectToAction("NotFound", "Home");

            var vm = new AdDetailDetailViewModel()
            {
                Id = adDetail.Id,
                Name = adDetail.Name,
                ThumbPath = adDetail.ThumbPath,
                CreatedDateTime = adDetail.CreatedDateTime,
                Description = adDetail.Description,
                Price = adDetail.Price,
                UpdatedDateTime = adDetail.UpdatedDateTime,
                Size = adDetail.Size,
                BAge = adDetail.BAge,
                Dues = adDetail.Dues,
                Isinma = adDetail.Isinma,
                Status = adDetail.Status,
                Kimden = adDetail.Kimden,
                KrediDurumu = adDetail.Kredi,
                Kur = adDetail.Kur,
                Expert = adDetail.Expert,
                Il = adDetail.Il,
                Ilce = adDetail.Ilce,
                Semt = adDetail.Semt,
                SelectedProperties = adDetail.SelectedProperties.Select(x => x.Value).ToArray(),
                SelectedSecurities = adDetail.SelectedSecurities.Select(x => x.Value).ToArray(),
                SelectedSocialList = adDetail.SelectedSocialApps.Select(x => x.Value).ToArray(),
                FileDetails = adDetail.WorkFileDetails
            };
            return View(vm);
        }
        public ActionResult BuildDetail(int id)
        {
            var adDetail = _binaService.GetActiveRecordById(id);
            if (adDetail == null)
                return RedirectToAction("NotFound", "Home");

            var vm = new AdDetailDetailViewModel()
            {
                Id = adDetail.Id,
                Name = adDetail.Name,
                ThumbPath = adDetail.ThumbPath,
                CreatedDateTime = adDetail.CreatedDateTime,
                Description = adDetail.Description,
                Price = adDetail.Price,
                UpdatedDateTime = adDetail.UpdatedDateTime,
                Size = adDetail.Size,
                BAge = adDetail.BAge,
                Status = adDetail.Status,
                Kimden = adDetail.Kimden,
                Kur = adDetail.Kur,
                Expert = adDetail.Expert,
                Il = adDetail.Il,
                Ilce = adDetail.Ilce,
                Semt = adDetail.Semt,
                SelectedProperties = adDetail.SelectedProperties.Select(x => x.Value).ToArray(),
                SelectedSecurities = adDetail.SelectedSecurities.Select(x => x.Value).ToArray(),
                SelectedSocialList = adDetail.SelectedSocialApps.Select(x => x.Value).ToArray(),
                FileDetails = adDetail.FileDetails,
                FloorFlatCount = adDetail.FloorFlatCount,
                FloorCount = adDetail.FloorCount
            };
            return View(vm);
        }

    }
}
