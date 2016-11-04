using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Project_BLL.Interfaces;
using Project_BLL.ViewModels;
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
                    _projectRepository.Update(model.ToProject());
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
                        ProjectDeliveryDate = x.DeliveryDate
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