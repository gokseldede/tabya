using System;
using System.Collections.Generic;
using System.Globalization;
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

        public AdService()
        {
            _workPlaceRepository = new EfRepositoryForEntityBase<Workplace>();
            _adRepository = new EfRepositoryForEntityBase<AdDetail>();
            _landRepository = new EfRepositoryForEntityBase<Land>();
            _buildingRepository = new EfRepositoryForEntityBase<Bina>();
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
                BAge = data.BAge,
                BathroomCount = data.Bath,
                Dues = decimal.Parse(data.Dues),
                EmlakTipId = data.EmlakTipID,
                EsyaId = data.EsyaID,
                FlatFloor = int.Parse(data.FloorNumber),
                FloorCount = data.Floor,
                IsinmaId = data.IsinmaID,
                KimdenId = data.KimdenID,
                KrediId = data.KrediID,
                KullanimId = data.KullanimID,
                KurlarId = data.KurlarID,
                RoomCount = int.Parse(data.Room),
                SiteId = data.SiteID,
                StatusId = data.StatusID,
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