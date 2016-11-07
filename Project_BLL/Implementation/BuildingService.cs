using System;
using System.Linq;
using Project_BLL.Interfaces;
using Project_BLL.ServiceModels;
using Project_DAL;
using Project_Entity;

namespace Project_BLL.Implementation
{
    public class BuildingService : IStandartService<BuildingServiceModel>
    {
        private readonly IRepository<Bina> _buildingRepository;

        public BuildingService()
        {
            _buildingRepository=new EfRepositoryForEntityBase<Bina>();
        }

        public void ChangeStatus(int id)
        {
            var model = _buildingRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _buildingRepository.Update(model);
            }
        }

        public void ChangeVitrin(int id)
        {
            var model = _buildingRepository.GetById(id);
            if (model != null)
            {
                model.Vitrin = !model.Vitrin;
                _buildingRepository.Update(model);
            }
        }

        public void Create(BuildingServiceModel model)
        {
            Bina bina = new Bina()
            {
                BAge = model.BAge,
                Description = model.Description,
                EmlakTipID = 6, //TODO değiştir
                ExpertID = model.ExpertId,
                Floor = model.FloorCount,
                FloorRoom = model.FloorFlatCount,
                KimdenID = model.KimdenId,
                KurlarID = model.KurlarId,
                Name = model.Name,
                Price = model.Price,
                Size = model.Size.ToString(),
                StatusID = model.StatusId,
                Takas = model.Takas,
                ThumbPath = model.ThumbPath,
                BinaFileDetails = model.FileDetails.Select(x => new BinaFileDetail()
                {
                    Id = x.Id,
                    Extension = x.Extension,
                    FileName = x.FileName
                }).ToList()
            };

            _buildingRepository.Insert(bina);
        }

        public void DeleteById(int id)
        {
            _buildingRepository.Delete(id);
        }

        public void Edit(BuildingServiceModel model)
        {
            if (model != null)
            {
                var db = _buildingRepository.GetById(model.Id);
                if (db != null)
                {
                    db.BAge = model.BAge;
                    db.Description = model.Description;
                    db.EmlakTipID = 6; //TODO değiştir
                    db.ExpertID = model.ExpertId;
                    db.Floor = model.FloorCount;
                    db.FloorRoom = model.FloorFlatCount;
                    db.KimdenID = model.KimdenId;
                    db.KurlarID = model.KurlarId;
                    db.Name = model.Name;
                    db.Price = model.Price;
                    db.Size = model.Size.ToString();
                    db.StatusID = model.StatusId;
                    db.Takas = model.Takas;
                    db.ThumbPath = model.ThumbPath;
                    db.BinaFileDetails = model.FileDetails.Select(x => new BinaFileDetail()
                    {
                        Id = x.Id,
                        Extension = x.Extension,
                        FileName = x.FileName
                    }).ToList();

                    _buildingRepository.Update(db);
                }
            }
        }

        public
            System.Collections.Generic.IList<BuildingServiceModel> Get(System.Linq.Expressions.Expression<Func<BuildingServiceModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IList<BuildingServiceModel> GetAll()
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

        public BuildingServiceModel GetById(int id)
        {
            var data = _buildingRepository.GetById(id);
            if (data == null)
                return null;

            var vm = new BuildingServiceModel()
            {
                Id = data.ID,
                IsActive = data.IsActive,
                Name = data.Name,
                CreatedDateTime = data.CreatedDate,
                ThumbPath = data.ThumbPath,
                Description = data.Description,
                UpdatedDateTime = data.UpdatedDate,
                IsInVitrin = data.Vitrin,
                KimdenId = data.KimdenID,
                ExpertId = data.ExpertID,
                StatusId = data.StatusID,
                Size = int.Parse(data.Size),
                KurlarId = data.KurlarID,
                BAge = data.BAge,
                Price = data.Price,
                FloorCount = data.Floor,
                FloorFlatCount = data.FloorRoom,
                Takas = data.Takas,
                FileDetails = data.BinaFileDetails.Select(x => new FileDetailServiceModel() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList()
            };
            return vm;
        }
    }

}