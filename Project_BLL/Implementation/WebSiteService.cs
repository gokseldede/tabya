using Project_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Globalization;
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
                Where(x => x.IsDelete == false && x.Vitrin && x.IsActive).OrderByDescending(x=>x.CreatedDate).Select(x => new NewProject()
                {
                    Id = x.ID,
                    Name = x.Name,
                    Address = x.SSubName,
                    Company = x.SubName,
                    Photo = x.ImagePath
                }).ToList();
            vm.Advertisements = QueryAdvertisements(true);
            vm.Advertisements.AddRange(GetLands(true));
            vm.Advertisements.AddRange(GetWorkplaces(true));
            vm.Advertisements.AddRange(GetBuildings(true));
            return vm;
        }

        public List<NewAdvertisement> GetAdvertisements(QueryServiceModel model)
        {
            var advertisements = new List<NewAdvertisement>();

            if (model.AdType != null && model.AdType.ToLower() == "ofis")
                advertisements.AddRange(GetWorkplaces(model: model));
            else if (model.AdType != null && model.AdType.ToLower() == "arsa")
                advertisements.AddRange(GetLands(model: model));
            else if (model.AdType != null && model.AdType.ToLower() == "bina")
                advertisements.AddRange(GetBuildings(model: model));
            else if (model.AdType != null)
                advertisements.AddRange(QueryAdvertisements(model: model));
            else
            {
                advertisements.AddRange(GetWorkplaces(model: model));
                advertisements.AddRange(GetLands(model: model));
                advertisements.AddRange(GetBuildings(model: model));
                advertisements.AddRange(QueryAdvertisements(model: model));
            }
            return advertisements;
        }

        private List<NewAdvertisement> QueryAdvertisements(bool? vitrin = null, QueryServiceModel model = null)
        {
            IQueryable<AdDetail> query = _adDetailRepository.Table.Where(x => x.IsDelete == false && x.IsActive);

            if (vitrin != null)
                query = query.Where(x => x.Vitrin == vitrin);
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.Query))
                    query = query.Where(x => x.Name.Contains(model.Query));
                if (model.IlceId != 0)
                    query = query.Where(x => x.Semt.IlceID == model.IlceId);
                if (model.IlId != 0)
                    query = query.Where(x => x.Semt.Ilce.IlID == model.IlId);
                if (!string.IsNullOrEmpty(model.Oda))
                    query = query.Where(x => x.Room.Trim() == model.Oda.Trim());
                if (!string.IsNullOrEmpty(model.AdType))
                    query = query.Where(x => x.EmlakTip.Name.Trim().ToLower()== model.AdType.Trim().ToLower());
                if (!string.IsNullOrEmpty(model.Boyut))
                {
                    int minSize = int.Parse(model.Boyut.Split('-')[0]);
                    int maxSize = int.Parse(model.Boyut.Split('-')[1]);
                    query = query.Where(x => minSize <= x.Size && x.Size <= maxSize);
                }
            }

            return query.OrderByDescending(x=>x.CreatedDate).Select(x => new NewAdvertisement()
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

        private List<NewAdvertisement> GetLands(bool? vitrin = null, QueryServiceModel model = null)
        {
            IQueryable<Land> query = _landRepository.Table.Where(x => x.IsDelete == false && x.IsActive);

            if (vitrin != null)
                query = query.Where(x => x.Vitrin == vitrin);
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.Query))
                    query = query.Where(x => x.Name.Contains(model.Query));
                if (model.IlceId != 0)
                    query = query.Where(x => x.Semt.IlceID == model.IlceId);
                if (model.IlId != 0)
                    query = query.Where(x => x.Semt.Ilce.IlID == model.IlId);
                if (!string.IsNullOrEmpty(model.Boyut))
                {
                    int minSize = int.Parse(model.Boyut.Split('-')[0]);
                    int maxSize = int.Parse(model.Boyut.Split('-')[1]);
                    query = query.Where(x => minSize <= x.Size && x.Size <= maxSize);
                }
            }

            return query.OrderByDescending(x => x.CreatedDate).Select(x => new NewAdvertisement()
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


        private List<NewAdvertisement> GetBuildings(bool? vitrin = null, QueryServiceModel model = null)
        {
            IQueryable<Bina> query = _buildRepository.Table.Where(x => x.IsDelete == false && x.IsActive);

            if (vitrin != null)
                query = query.Where(x => x.Vitrin == vitrin);
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.Query))
                    query = query.Where(x => x.Name.Contains(model.Query));
                if (model.IlceId != 0)
                    query = query.Where(x => x.Semt.IlceID == model.IlceId);
                if (model.IlId != 0)
                    query = query.Where(x => x.Semt.Ilce.IlID == model.IlId);
                if (!string.IsNullOrEmpty(model.Boyut))
                {
                    int minSize = int.Parse(model.Boyut.Split('-')[0]);
                    int maxSize = int.Parse(model.Boyut.Split('-')[1]);
                    query = query.Where(x => minSize <= x.Size && x.Size <= maxSize);
                }
            }

            return query.OrderByDescending(x => x.CreatedDate).Select(x => new NewAdvertisement()
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

        private List<NewAdvertisement> GetWorkplaces(bool? vitrin = null, QueryServiceModel model = null)
        {
            IQueryable<Workplace> query = _workplaceRepository.Table.Where(x => x.IsDelete == false && x.IsActive);

            if (vitrin != null)
                query = query.Where(x => x.Vitrin == vitrin);
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.Query))
                    query = query.Where(x => x.Name.Contains(model.Query));
                if (model.IlceId != 0)
                    query = query.Where(x => x.Semt.IlceID == model.IlceId);
                if (model.IlId != 0)
                    query = query.Where(x => x.Semt.Ilce.IlID == model.IlId);
                if (!string.IsNullOrEmpty(model.Oda))
                    query = query.Where(x => x.Room.Trim().ToLower() == model.Oda.Trim().ToLower());
                if (!string.IsNullOrEmpty(model.Boyut))
                {
                    int minSize = int.Parse(model.Boyut.Split('-')[0]);
                    int maxSize = int.Parse(model.Boyut.Split('-')[1]);
                    query = query.Where(x => minSize <= x.Size && x.Size <= maxSize);
                }
            }


            return query.OrderByDescending(x => x.CreatedDate).Select(x => new NewAdvertisement()
            {
                Id = x.ID,
                Photo = x.ThumbPath,
                Currency = x.Kurlar.Name,
                Status = x.Status.Name,
                Price = x.Price,
                SquareMetre = x.Size,
                AdType = x.EmlakTip.Name,
                Address = x.Semt.Ilce.Ad + ", " + x.Semt.Ilce.Il.Ad
            }).ToList();
        }

        public void AddToNewster(string email, string ipAddres)
        {
            _newsletterRepository.Insert(new Newsletter() { Email = email, IpAddress = ipAddres });
        }
    }
}
