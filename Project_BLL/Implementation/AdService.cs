using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;
using Project_DAL;
using Project_Entity;

namespace Project_BLL.Implementation
{
    public class AdService : IAdService
    {
        private readonly IRepository<Bina> _buildingRepository;
        private readonly IRepository<Land> _landRepository;
        private readonly IRepository<Workplace> _workPlaceRepository;
        private readonly IRepository<AdDetail> _adRepository;
        private readonly IRepository<Securitys> _securityRepository;
        private readonly IRepository<SocialApps> _socialAppsRepository;
        private readonly IRepository<Properties> _propertiesRepository;

        public AdService()
        {
            ProjectContext coneContext = new ProjectContext();
            _workPlaceRepository = new EfRepositoryForEntityBase<Workplace>();
            _adRepository = new EfRepositoryForEntityBase<AdDetail>(coneContext);
            _landRepository = new EfRepositoryForEntityBase<Land>();
            _buildingRepository = new EfRepositoryForEntityBase<Bina>();
            _securityRepository = new EfRepositoryForEntityBase<Securitys>(coneContext);
            _socialAppsRepository = new EfRepositoryForEntityBase<SocialApps>(coneContext);
            _propertiesRepository = new EfRepositoryForEntityBase<Properties>(coneContext);
        }

        public void Create(AdDetailServiceModel model)
        {

            var adDetail = new AdDetail()
            {
                ID = model.Id,
                Name = model.Name,
                ThumbPath = model.ThumbPath,
                Description = model.Description,
                Price = model.Price,
                Size = model.Size,
                ExpertID = model.ExpertId,
                BAge = model.BAge,
                Bath = model.BathroomCount,
                Dues = model.Dues.ToString(),
                EmlakTipID = model.EmlakTipId,
                EsyaID = model.EsyaId,
                FloorNumber = model.FlatFloor.ToString(),
                Floor = model.FloorCount,
                IsinmaID = model.IsinmaId,
                KimdenID = model.KimdenId,
                KrediID = model.KrediId,
                KullanimID = model.KullanimId,
                KurlarID = model.KurlarId,
                Room = model.RoomCount.ToString(),
                SiteID = model.SiteId,
                StatusID = model.StatusId,
                FileDetails =
                model.FileDetails.Select(
                    x => new FileDetail() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList(),
            };

            adDetail.Securities = _securityRepository.Table.Where(x => model.SelectedSecurities.Any(y=>y.Id==x.ID)).ToList();
            adDetail.Propertieses = _propertiesRepository.Table.Where(x => model.SelectedProperties.Any(y => y.Id == x.ID)).ToList();
            adDetail.SocialAppses = _socialAppsRepository.Table.Where(x => model.SelectedSocialApps.Any(y => y.Id == x.ID)).ToList();

            _adRepository.Insert(adDetail);
        }

        public void Edit(AdDetailServiceModel model)
        {
            if (model != null)
            {
                var data = _adRepository.GetById(model.Id);
                if (data != null)
                {
                    data.ID = model.Id;
                    data.Name = model.Name;
                    data.ThumbPath = model.ThumbPath;
                    data.Description = model.Description;
                    data.Price = model.Price;
                    data.Size = model.Size;
                    data.ExpertID = model.ExpertId;
                    data.BAge = model.BAge;
                    data.Bath = model.BathroomCount;
                    data.Dues = model.Dues.ToString();
                    data.EmlakTipID = model.EmlakTipId;
                    data.EsyaID = model.EsyaId;
                    data.FloorNumber = model.FlatFloor.ToString();
                    data.Floor = model.FloorCount;
                    data.IsinmaID = model.IsinmaId;
                    data.KimdenID = model.KimdenId;
                    data.KrediID = model.KrediId;
                    data.KullanimID = model.KullanimId;
                    data.KurlarID = model.KurlarId;
                    data.Room = model.RoomCount.ToString();
                    data.SiteID = model.SiteId;
                    data.StatusID = model.StatusId;
                    data.FileDetails =
                        model.FileDetails.Select(
                            x => new FileDetail() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList();

                    foreach (var item in data.Securities.ToList())
                        if (model.SelectedSecurities.All(y => y.Id != item.ID))
                            data.Securities.Remove(item);

                    data.Securities = _securityRepository.Table.Where(x => model.SelectedSecurities.Any(y => y.Id == x.ID)).ToList();

                    foreach (var item in data.Propertieses.ToList())
                        if (model.SelectedProperties.All(y => y.Id != item.ID))
                            data.Propertieses.Remove(item);

                    data.Propertieses = _propertiesRepository.Table.Where(x => model.SelectedProperties.Any(y => y.Id == x.ID)).ToList();

                    foreach (var item in data.SocialAppses.ToList())
                        if (model.SelectedSocialApps.All(y => y.Id != item.ID))
                            data.SocialAppses.Remove(item);

                    data.SocialAppses = _socialAppsRepository.Table.Where(x => model.SelectedSocialApps.Any(y => y.Id == x.ID)).ToList();

                    _adRepository.Update(data);
                }

            }
        }

        public AdDetailServiceModel GetById(int id)
        {
            var data = _adRepository.GetById(id);
            if (data == null)
                return null;

            var vm = new AdDetailServiceModel()
            {
                Id = data.ID,
                IsActive = data.IsActive,
                Name = data.Name,
                ThumbPath = data.ThumbPath,
                CreatedDateTime = data.CreatedDate,
                Description = data.Description,
                IsInVitrin = data.Vitrin,
                UpdatedDateTime = data.UpdatedDate,
                Price = data.Price,
                Size = data.Size,
                ExpertId = data.ExpertID,
                Expert=data.Expert,
                BAge = data.BAge,
                BathroomCount = data.Bath,
                Dues = decimal.Parse(data.Dues),
                EmlakTipId = data.EmlakTipID,
                EmlakTip = data.EmlakTip.Name,
                EsyaId = data.EsyaID,
                Esya = data.Esya.Name,
                FlatFloor = int.Parse(data.FloorNumber),
                FloorCount = data.Floor,
                IsinmaId = data.IsinmaID,
                Isinma = data.Isinma.Name,
                KimdenId = data.KimdenID,
                Kimden=data.Kimden.Name,
                KrediId = data.KrediID,
                Kredi = data.Kredi.Name,
                KullanimId = data.KullanimID,
                Kullanim=data.Kullanim.Name,
                KurlarId = data.KurlarID,
                Kur=data.Kurlar.Name,
                RoomCount = int.Parse(data.Room),
                SiteId = data.SiteID,
                Site = data.Site.Name,
                StatusId = data.StatusID,
                Status=data.Status.Name,
                SelectedProperties = data.Propertieses.Select(x =>new SelectlistItem() {Id=x.ID,Value = x.Name}).ToList(),
                SelectedSecurities = data.Securities.Select(x => new SelectlistItem() { Id = x.ID, Value = x.Name }).ToList(),
                SelectedSocialApps = data.SocialAppses.Select(x => new SelectlistItem() { Id = x.ID, Value = x.Name }).ToList(),
                FileDetails = data.FileDetails.Select(x => new FileDetailServiceModel()
                {
                    Id = x.Id,
                    Extension = x.Extension,
                    FileName = x.FileName
                }).ToList()
            };
            return vm;
        }

        public void DeleteById(int id)
        {
            _adRepository.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            var model = _adRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _adRepository.Update(model);
            }
        }

        public IList<AdDetailServiceModel> GetAll()
        {
            return _adRepository.Table.Where(x => x.IsDelete == false)
                .Select(x => new AdDetailServiceModel()
                {
                    Id = x.ID,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    IsInVitrin = x.Vitrin,
                    CreatedDateTime = x.CreatedDate,
                    UpdatedDateTime = x.UpdatedDate,
                    ThumbPath = x.ThumbPath
                })
                .ToList();
        }

        public IList<AdDetailServiceModel> Get(Expression<Func<AdDetailServiceModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            var model = _adRepository.GetById(id);
            if (model != null)
            {
                model.Vitrin = !model.Vitrin;
                _adRepository.Update(model);
            }
        }

        public List<WorkplaceServiceModel> GetWorkPlaces()
        {
            return _workPlaceRepository.Table.Where(x => x.IsDelete == false).Select(x => new WorkplaceServiceModel()
            {
                Id = x.ID,
                ThumbPath = x.ThumbPath,
                Name = x.Name,
                IsActive = x.IsActive,
                CreatedDateTime = x.CreatedDate,
                UpdatedDateTime = x.UpdatedDate,
                IsInVitrin = x.Vitrin
            }).ToList();
        }

        public List<LandServiceModel> GetLands()
        {
            return _landRepository.Table.Where(x => x.IsDelete == false)
                  .Select(x => new LandServiceModel()
                  {
                      Id = x.ID,
                      ThumbPath = x.ThumbPath,
                      Name = x.Name,
                      IsActive = x.IsActive,
                      IsInVitrin = x.Vitrin,
                      CreatedDateTime = x.CreatedDate,
                      UpdatedDateTime = x.UpdatedDate
                  })
                  .ToList();
        }

        public List<BuildingServiceModel> GetBuildings()
        {
            return
               _buildingRepository.Table.Where(x => x.IsDelete == false)
                   .Select(x => new BuildingServiceModel()
                   {
                       Id = x.ID,
                       ThumbPath = x.ThumbPath,
                       Name = x.Name,
                       IsActive = x.IsActive,
                       IsInVitrin = x.Vitrin,
                       CreatedDateTime = x.CreatedDate,
                       UpdatedDateTime = x.UpdatedDate
                   })
                   .ToList();
        }
    }
}