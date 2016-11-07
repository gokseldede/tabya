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

        public ProjectService()
        {
            _projectRepository = new EfRepositoryForEntityBase<Project>();
        }

        public void Create(ProjectServiceModel model)
        {
            _projectRepository.Insert(model.ToProject());
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
                    db.HouseN = model.FlatCount.ToString();
                    db.ImagePath = model.ThumbPath;
                    db.Name = model.Name;
                    db.PriceList = model.PriceList;
                    db.ProjectA = model.ProjectArea.ToString("F2");
                    db.SSubName = model.ProjectLocation;
                    db.SubName = model.ProjectFirm;
                    db.Video = model.ProjectPromotionVideo;
                    db.ProjectFiles =
                        model.ProjectFileDetails.Select(
                            x => new ProjectFile() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList();

                    _projectRepository.Update(db);
                }
            }
        }

        public ProjectServiceModel GetById(int id)
        {
            var data = _projectRepository.GetById(id);
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
            return
                _projectRepository.Table.Where(x => x.IsDelete == false)
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
                        ProjectFirm = x.SubName
                    }).ToList();
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