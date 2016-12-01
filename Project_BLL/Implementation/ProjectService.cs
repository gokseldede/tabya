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
    public class ProjectService : IStandartService<ProjectServiceModel>
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<Securitys> _securityRepository;
        private readonly IRepository<SocialApps> _socialAppsRepository;
        private readonly IRepository<Properties> _propertiesRepository;

        public ProjectService()
        {
            ProjectContext coneContext = new ProjectContext();
            _projectRepository = new EfRepositoryForEntityBase<Project>(coneContext);
            _securityRepository = new EfRepositoryForEntityBase<Securitys>(coneContext);
            _socialAppsRepository = new EfRepositoryForEntityBase<SocialApps>(coneContext);
            _propertiesRepository = new EfRepositoryForEntityBase<Properties>(coneContext);
        }

        public void Create(ProjectServiceModel model)
        {
            var db = model.ToProject();
            int[] securitiesIds = model.SelectedSecurities.Select(y => y.Id).ToArray();
            int[] propertiesIds = model.SelectedProperties.Select(y => y.Id).ToArray();
            int[] socialAppsIds = model.SelectedSocialApps.Select(y => y.Id).ToArray();
            db.Securities = _securityRepository.Table.Where(x => securitiesIds.Contains(x.ID)).ToList();
            db.Propertieses = _propertiesRepository.Table.Where(x => propertiesIds.Contains(x.ID)).ToList();
            db.SocialAppses = _socialAppsRepository.Table.Where(x => socialAppsIds.Contains(x.ID)).ToList();
            _projectRepository.Insert(db);
        }

        public void Edit(ProjectServiceModel model)
        {
            if (model != null)
            {
                var db = _projectRepository.GetById(model.Id);
                if (db != null)
                {
                    db.ID = model.Id;
                    db.DeliveryDate = model.ProjectDeliveryDate;
                    db.Description = model.Description;
                    db.ExpertID = model.ExpertId;
                    db.HouseN = model.FlatCount;
                    db.ImagePath = model.ThumbPath;
                    db.Name = model.Name;
                    db.PriceList = model.PriceList;
                    db.ProjectA = model.ProjectArea;
                    db.SSubName = model.ProjectLocation;
                    db.SubName = model.ProjectFirm;
                    db.Video = model.ProjectPromotionVideo;
                    db.ProjectFiles =
                        model.ProjectFileDetails.Select(
                            x => new ProjectFile() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList();

                    int[] securitiesIds = model.SelectedSecurities.Select(y => y.Id).ToArray();
                    int[] propertiesIds = model.SelectedProperties.Select(y => y.Id).ToArray();
                    int[] socialAppsIds = model.SelectedSocialApps.Select(y => y.Id).ToArray();
                    foreach (var item in db.Securities.ToList())
                        if (model.SelectedSecurities.All(y => y.Id != item.ID))
                            db.Securities.Remove(item);

                    db.Securities = _securityRepository.Table.Where(x => securitiesIds.Contains(x.ID)).ToList();

                    foreach (var item in db.Propertieses.ToList())
                        if (model.SelectedProperties.All(y => y.Id != item.ID))
                            db.Propertieses.Remove(item);

                    db.Propertieses = _propertiesRepository.Table.Where(x => propertiesIds.Contains(x.ID)).ToList();

                    foreach (var item in db.SocialAppses.ToList())
                        if (model.SelectedSocialApps.All(y => y.Id != item.ID))
                            db.SocialAppses.Remove(item);

                    db.SocialAppses = _socialAppsRepository.Table.Where(x => socialAppsIds.Contains(x.ID)).ToList();
                    _projectRepository.Update(db);
                }
            }
        }

        public ProjectServiceModel GetById(int id)
        {
            var data = _projectRepository.GetById(id);
            return data?.ToProjectServiceModel();
        }

        public ProjectServiceModel GetActiveRecordById(int id)
        {
            var data = _projectRepository.Table.SingleOrDefault(x => x.IsActive && x.ID == id);
            return data?.ToProjectServiceModel();
        }

        public void DeleteById(int id)
        {
            _projectRepository.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            var model = _projectRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _projectRepository.Update(model);
            }
        }

        public IList<ProjectServiceModel> GetAll()
        {
            return _projectRepository.Table.Where(x => x.IsDelete == false)
                    .Select(x => new ProjectServiceModel()
                    {
                        Id = x.ID,
                        ThumbPath = x.ImagePath,
                        Name = x.Name,
                        IsActive = x.IsActive,
                        CreatedDateTime = x.CreatedDate,
                        UpdatedDateTime = x.UpdatedDate,
                        IsInVitrin = x.Vitrin,
                        ProjectDeliveryDate = x.DeliveryDate,
                        ProjectFirm = x.SubName,
                        ProjectLocation = x.SSubName
                    }).OrderByDescending(x=>x.CreatedDateTime).ToList();
        }

        public IList<ProjectServiceModel> Get(Expression<Func<ProjectServiceModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            var model = _projectRepository.GetById(id);
            if (model != null)
            {
                model.Vitrin = !model.Vitrin;
                _projectRepository.Update(model);
            }
        }
    }
}