using Project_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using Project_BLL.ServiceModels;
using Project_Entity;
using Project_DAL;
using Project_Entity.Entities;

namespace Project_BLL.Implementation
{
    public class WebSiteService : IWebSiteService
    {
        private readonly IOptionService _optionService;
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<AdDetail> _adDetailRepository;
        private readonly IRepository<Land> _landRepository;
        private readonly IRepository<Workplace> _workplaceRepository;
        private readonly IRepository<Bina> _buildRepository;
        private readonly IRepository<Newsletter> _newsletterRepository;

        public WebSiteService()
        {
            _optionService = new OptionsService();
            _projectRepository = new EfRepositoryForEntityBase<Project>();
            _adDetailRepository = new EfRepositoryForEntityBase<AdDetail>();
            _landRepository = new EfRepositoryForEntityBase<Land>();
            _workplaceRepository = new EfRepositoryForEntityBase<Workplace>();
            _buildRepository = new EfRepositoryForEntityBase<Bina>();
            _newsletterRepository = new EfRepositoryForEntityBase<Newsletter>();
        }
        public List<SelectlistItem> GetCities()
        {
            throw new NotImplementedException();
        }

        public List<SelectlistItem> GetCounties(int cityId)
        {
            return _optionService.GetIlcelerList(cityId).ToList();
        }

        public List<SelectlistItem> GetProviences(int countyId)
        {
            return _optionService.GetSemtList(countyId).ToList();
        }

        public HomeViewModel GetMainPageData()
        {
            var vm = new HomeViewModel();
            vm.Cities = _optionService.GetIllerList().ToList();
            vm.Projects = _projectRepository.Table.
                Where(x => x.IsDelete == false && x.Vitrin && x.IsActive).Select(x => new NewProject()
                {
                    Id = x.ID,
                    Name = x.Name,
                    Address = x.SSubName,
                    Company = x.SubName,
                    Photo = x.ImagePath
                }).ToList();
            vm.Advertisements = GetAdvertisements(true);
            vm.Advertisements.AddRange(GetLands(true));
            vm.Advertisements.AddRange(GetWorkplaces(true));
            vm.Advertisements.AddRange(GetBuildings(true));
            return vm;
        }

        public List<NewAdvertisement> GetAdvertisements(string query = null)
        {
            var advertisements = new List<NewAdvertisement>();

            advertisements.AddRange(GetWorkplaces(name: query));
            advertisements.AddRange(GetLands(name: query));
            advertisements.AddRange(GetAdvertisements(name: query));
            advertisements.AddRange(GetBuildings(name: query));
            return advertisements;
        }

        private List<NewAdvertisement> GetAdvertisements(bool? vitrin = null, string name = null)
        {
            IQueryable<AdDetail> query;
            if (vitrin != null && !string.IsNullOrEmpty(name))
                query = _adDetailRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin && x.Name.Contains(name)).AsQueryable();
            else if (vitrin != null)
                query = _adDetailRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin).AsQueryable();
            else if (!string.IsNullOrEmpty(name))
                query = _adDetailRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Name.Contains(name)).AsQueryable();
            else
                query = _adDetailRepository.Table.Where(x => x.IsDelete == false && x.IsActive).AsQueryable();

            return query.Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                AdType = x.EmlakTip.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                Address = x.Semt.Ilce.Ad + ", " + x.Semt.Ilce.Il.Ad
            }).ToList();
        }

        private List<NewAdvertisement> GetLands(bool? vitrin = null, string name = null)
        {
            IQueryable<Land> query;
            if (vitrin != null && !string.IsNullOrEmpty(name))
                query = _landRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin && x.Name.Contains(name)).AsQueryable();
            else if (vitrin != null)
                query = _landRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin).AsQueryable();
            else if (!string.IsNullOrEmpty(name))
                query = _landRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Name.Contains(name)).AsQueryable();
            else
                query = _landRepository.Table.Where(x => x.IsDelete == false && x.IsActive).AsQueryable();

            return query.Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                AdType = "Arsa",
                Address = x.Semt.Ilce.Ad + ", " + x.Semt.Ilce.Il.Ad
            }).ToList();
        }

        private List<NewAdvertisement> GetBuildings(bool? vitrin = null, string name = null)
        {
            IQueryable<Bina> query;
            if (vitrin != null && !string.IsNullOrEmpty(name))
                query = _buildRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin && x.Name.Contains(name)).AsQueryable();
            else if (vitrin != null)
                query = _buildRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin).AsQueryable();
            else if (!string.IsNullOrEmpty(name))
                query = _buildRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Name.Contains(name)).AsQueryable();
            else
                query = _buildRepository.Table.Where(x => x.IsDelete == false && x.IsActive).AsQueryable();

            return query.Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                AdType = x.EmlakTip.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                Address = x.Semt.Ilce.Ad + ", " + x.Semt.Ilce.Il.Ad
            }).ToList();
        }

        private List<NewAdvertisement> GetWorkplaces(bool? vitrin = null, string name = null)
        {
            IQueryable<Workplace> query;
            if (vitrin != null && !string.IsNullOrEmpty(name))
                query = _workplaceRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin && x.Name.Contains(name)).AsQueryable();
            else if (vitrin != null)
                query = _workplaceRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Vitrin == vitrin).AsQueryable();
            else if (!string.IsNullOrEmpty(name))
                query = _workplaceRepository.Table.Where(x => x.IsDelete == false && x.IsActive && x.Name.Contains(name)).AsQueryable();
            else
                query = _workplaceRepository.Table.Where(x => x.IsDelete == false && x.IsActive).AsQueryable();


            return query.Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                AdType = "İşyeri",
                Address = x.Semt.Ilce.Ad + ", " + x.Semt.Ilce.Il.Ad
            }).ToList();
        }

        public void AddToNewster(string email, string ipAddres)
        {
            _newsletterRepository.Insert(new Newsletter() { Email = email, IpAddress = ipAddres });
        }
    }
}
