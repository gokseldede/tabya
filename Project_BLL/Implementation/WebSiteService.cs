using Project_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Project_BLL.ServiceModels;
using Project_Entity;
using Project_DAL;

namespace Project_BLL.Implementation
{
    public class WebSiteService : IWebSiteService
    {
        private readonly IOptionService _optionService;
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<AdDetail> _adDetailRepository;
        private readonly IRepository<Land> _landRepository;
        private readonly IRepository<Workplace> _workplaceRepository;


        public WebSiteService()
        {
            _optionService = new OptionsService();
            _projectRepository = new EfRepositoryForEntityBase<Project>();
            _adDetailRepository = new EfRepositoryForEntityBase<AdDetail>();
            _landRepository = new EfRepositoryForEntityBase<Land>();
            _workplaceRepository = new EfRepositoryForEntityBase<Workplace>();
        }
        public List<SelectlistItem> GetCities()
        {
            throw new NotImplementedException();
        }

        public List<SelectlistItem> GetCounties(int cityId)
        {
            return _optionService.GetIlcelerList(cityId).ToList();
        }

        public HomeViewModel GetMainPageData()
        {
            var vm = new HomeViewModel();
            vm.Cities = _optionService.GetIllerList().ToList();
            vm.Projects = _projectRepository.Table.
                Where(x => x.IsDelete == false && x.Vitrin).Select(x => new NewProject()
                {
                    Id = x.ID,
                    Name = x.Name,
                    Address = x.SSubName,
                    Company = x.SubName,
                    Photo = x.ImagePath
                }).ToList();
            vm.Advertisements =
                _adDetailRepository.Table.Where(x => x.IsDelete == false && x.Vitrin).Select(x => new NewAdvertisement()
                {
                    Id = x.ID,
                    Photo = x.ThumbPath,
                    Currency = x.Kurlar.Name,
                    Status = x.Status.Name,
                    AdType = x.EmlakTip.Name,
                    Price = x.Price,
                    SquareMetre = x.Size
                }).ToList();

            vm.Advertisements.AddRange(_landRepository.Table.Where(x => x.IsDelete == false && x.Vitrin).Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                AdType="Arsa"
            }).ToList());
            vm.Advertisements.AddRange(_workplaceRepository.Table.Where(x => x.IsDelete == false && x.Vitrin).Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                AdType = "İşyeri"
            }).ToList());
            return vm;
        }

    }
}
