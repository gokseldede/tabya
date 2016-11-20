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
    public class WorkPlaceService : IStandartService<WorkplaceServiceModel>
    {
        private readonly IRepository<Workplace> _workPlaceRepository;
        private readonly IRepository<Securitys> _securityRepository;
        private readonly IRepository<SocialApps> _socialAppsRepository;
        private readonly IRepository<Properties> _propertiesRepository;

        public WorkPlaceService()
        {
            ProjectContext coneContext = new ProjectContext();
            _workPlaceRepository = new EfRepositoryForEntityBase<Workplace>();
            _securityRepository = new EfRepositoryForEntityBase<Securitys>(coneContext);
            _socialAppsRepository = new EfRepositoryForEntityBase<SocialApps>(coneContext);
            _propertiesRepository = new EfRepositoryForEntityBase<Properties>(coneContext);
        }

        public void Create(WorkplaceServiceModel model)
        {
            Workplace workplace = new Workplace
            {
                ThumbPath = model.ThumbPath,
                IsýnmaID = model.IsinmaId,
                KimdenID = model.KimdenId,
                KrediID = model.KrediId,
                KurlarID = model.KurlarId,
                Name = model.Name,
                Room = model.Room,
                Size = model.Size,
                BAge = model.BAge,
                Description = model.Description,
                Dues = model.Dues.ToString(),
                StatusID = model.StatusId,
                ExpertID = model.ExpertId,
                Price = model.Price,
                WorkFileDetails = model.WorkFileDetails.Select(x => new WorkFileDetail() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList(),
                EmlakTipID = 2, //TODO: düzelt

            };
            workplace.Securities = _securityRepository.Table.Where(x => model.SelectedSecurities.Any(y => y.Id == x.ID)).ToList();
            workplace.Propertieses = _propertiesRepository.Table.Where(x => model.SelectedProperties.Any(y => y.Id == x.ID)).ToList();
            workplace.SocialAppses = _socialAppsRepository.Table.Where(x => model.SelectedSocialApps.Any(y => y.Id == x.ID)).ToList();
            _workPlaceRepository.Insert(workplace);
        }

        public void Edit(WorkplaceServiceModel model)
        {
            if (model != null)
            {
                var db = _workPlaceRepository.GetById(model.Id);
                if (db != null)
                {
                    db.ThumbPath = model.ThumbPath;
                    db.IsýnmaID = model.IsinmaId;
                    db.KimdenID = model.KimdenId;
                    db.KrediID = model.KrediId;
                    db.KurlarID = model.KurlarId;
                    db.Name = model.Name;
                    db.Room = model.Room;
                    db.Size = model.Size;
                    db.BAge = model.BAge;
                    db.Description = model.Description;
                    db.Dues = model.Dues.ToString();
                    db.StatusID = model.StatusId;
                    db.ExpertID = model.ExpertId;
                    db.Price = model.Price;
                    db.WorkFileDetails = model.WorkFileDetails.Select(x => new WorkFileDetail() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList();
                    db.EmlakTipID = 2; //TODO: düzelt

                    foreach (var item in db.Securities.ToList())
                        if (model.SelectedSecurities.All(y => y.Id != item.ID))
                            db.Securities.Remove(item);

                    db.Securities = _securityRepository.Table.Where(x => model.SelectedSecurities.Any(y => y.Id == x.ID)).ToList();

                    foreach (var item in db.Propertieses.ToList())
                        if (model.SelectedProperties.All(y => y.Id != item.ID))
                            db.Propertieses.Remove(item);

                    db.Propertieses = _propertiesRepository.Table.Where(x => model.SelectedProperties.Any(y => y.Id == x.ID)).ToList();

                    foreach (var item in db.SocialAppses.ToList())
                        if (model.SelectedSocialApps.All(y => y.Id != item.ID))
                            db.SocialAppses.Remove(item);

                    db.SocialAppses = _socialAppsRepository.Table.Where(x => model.SelectedSocialApps.Any(y => y.Id == x.ID)).ToList();

                    _workPlaceRepository.Update(db);
                }
            }
        }

        public WorkplaceServiceModel GetById(int id)
        {
            var data = _workPlaceRepository.GetById(id);
            if (data == null)
                return null;

            var vm = new WorkplaceServiceModel
            {
                Id = data.ID,
                ThumbPath = data.ThumbPath,
                BAge = data.BAge,
                CreatedDateTime = data.CreatedDate,
                Description = data.Description,
                Dues = int.Parse(data.Dues),
                ExpertId = data.ExpertID,
                Expert=data.Expert,
                UpdatedDateTime = data.UpdatedDate,
                IsActive = data.IsActive,
                StatusId = data.StatusID,
                Status=data.Status.Name,
                Price = data.Price,
                Name = data.Name,
                Kur=data.Kurlar.Name,
                KurlarId = data.KurlarID,
                Room = data.Room,
                Size = data.Size,
                Isinma=data.Isýnma.Name,
                IsinmaId = data.IsýnmaID,
                Kimden=data.Kimden.Name,
                KimdenId = data.KimdenID,
                Kredi=data.Kredi.Name,
                KrediId = data.KrediID,
                SelectedProperties = data.Propertieses.Select(x => new SelectlistItem() { Id = x.ID, Value = x.Name }).ToList(),
                SelectedSecurities = data.Securities.Select(x => new SelectlistItem() { Id = x.ID, Value = x.Name }).ToList(),
                SelectedSocialApps = data.SocialAppses.Select(x => new SelectlistItem() { Id = x.ID, Value = x.Name }).ToList(),
                WorkFileDetails = data.WorkFileDetails.Select(
                    x => new FileDetailServiceModel() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList(),
                IsInVitrin = data.Vitrin
            };


            return vm;
        }

        public void DeleteById(int id)
        {
            _workPlaceRepository.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            var model = _workPlaceRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _workPlaceRepository.Update(model);
            }
        }

        public IList<WorkplaceServiceModel> Get(Expression<Func<WorkplaceServiceModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            var model = _workPlaceRepository.GetById(id);
            if (model != null)
            {
                model.Vitrin = !model.Vitrin;
                _workPlaceRepository.Update(model);
            }
        }

        public IList<WorkplaceServiceModel> GetAll()
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

    }
}
