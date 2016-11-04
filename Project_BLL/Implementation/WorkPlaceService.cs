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
    public class WorkPlaceService : IStandartService<WorkplaceServiceModel>
    {
        private readonly IRepository<Workplace> _workPlaceRepository;

        public WorkPlaceService()
        {
            _workPlaceRepository = new EfRepositoryForEntityBase<Workplace>();
        }

        public void Create(WorkplaceServiceModel model)
        {
            Workplace workplace = new Workplace
            {
                ThumbPath = model.ThumbPath,
                IsınmaID = model.IsinmaId,
                KimdenID = model.KimdenId,
                KrediID = model.KrediId,
                KurlarID = model.KurlarId,
                Name = model.Name,
                Room = model.Room,
                Size = model.Size.ToString(),
                BAge = model.BAge,
                Description = model.Description,
                Dues = model.Dues.ToString(),
                StatusID = model.StatusId,
                ExpertID = model.ExpertId,
                Price = model.Price.ToString("##.###"),
                WorkFileDetails = model.WorkFileDetails.Select(x => new WorkFileDetail() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList(),
                EmlakTipID = 2, //TODO: düzelt

            };

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
                    db.IsınmaID = model.IsinmaId;
                    db.KimdenID = model.KimdenId;
                    db.KrediID = model.KrediId;
                    db.KurlarID = model.KurlarId;
                    db.Name = model.Name;
                    db.Room = model.Room;
                    db.Size = model.Size.ToString();
                    db.BAge = model.BAge;
                    db.Description = model.Description;
                    db.Dues = model.Dues.ToString();
                    db.StatusID = model.StatusId;
                    db.ExpertID = model.ExpertId;
                    db.Price = model.Price.ToString("##.###");
                    db.WorkFileDetails = model.WorkFileDetails.Select(x => new WorkFileDetail() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList();
                    db.EmlakTipID = 2; //TODO: düzelt
                    
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
                UpdatedDateTime = data.UpdatedDate,
                IsActive = data.IsActive,
                StatusId = data.StatusID,
                Price = decimal.Parse(data.Price),
                Name = data.Name,
                KurlarId = data.KurlarID,
                Room = data.Room,
                Size = int.Parse(data.Size),
                IsinmaId = data.IsınmaID,
                KimdenId = data.KimdenID,
                KrediId = data.KrediID,
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
