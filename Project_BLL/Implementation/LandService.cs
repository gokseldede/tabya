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
    public class LandService : IStandartService<LandServiceModel>
    {
        private readonly IRepository<Land> _landRepository;

        public LandService()
        {
            _landRepository = new EfRepositoryForEntityBase<Land>();
        }

        public void Create(LandServiceModel model)
        {
            Land land = new Land()
            {
                Takas = model.Takas,
                AdaNo = model.AdaNo,
                Description = model.Description,
                ExpertID = model.ExpertId,
                Gabari = model.Gabari,
                ImarID = model.ImarId,
                Kaks = model.Emsal,
                KatKarsiligi = model.KatKarsiligi,
                KimdenID = model.KimdenId,
                KrediID = model.KrediId,
                KurlarID = model.KurlarId,
                PaftaNo = model.PaftaNo,
                Name = model.Name,
                ParselNo = model.ParselNo,
                Price = model.Price,
                Size = model.Size,
                StatusID = model.StatusId,
                SizePrice = model.PriceForM2,
                Tapu = model.TapuDurumu,
                ThumbPath = model.ThumbPath,
                SemtID = model.SemtId,
                LandFileDetails = model.FileDetails.Select(x => new LandFileDetail()
                {
                    Id = x.Id,
                    Extension = x.Extension,
                    FileName = x.FileName
                }).ToList()
            };

            _landRepository.Insert(land);
        }

        public void Edit(LandServiceModel model)
        {
            if (model != null)
            {
                var db = _landRepository.GetById(model.Id);
                if (db != null)
                {
                    db.Takas = model.Takas;
                    db.AdaNo = model.AdaNo;
                    db.Description = model.Description;
                    db.ExpertID = model.ExpertId;
                    db.Gabari = model.Gabari;
                    db.ImarID = model.ImarId;
                    db.Kaks = model.Emsal;
                    db.KatKarsiligi = model.KatKarsiligi;
                    db.KimdenID = model.KimdenId;
                    db.KrediID = model.KrediId;
                    db.KurlarID = model.KurlarId;
                    db.PaftaNo = model.PaftaNo;
                    db.Name = model.Name;
                    db.ParselNo = model.ParselNo;
                    db.Price = model.Price;
                    db.Size = model.Size;
                    db.StatusID = model.StatusId;
                    db.SizePrice = model.PriceForM2;
                    db.Tapu = model.TapuDurumu;
                    db.ThumbPath = model.ThumbPath;
                    db.SemtID = model.SemtId;
                    db.LandFileDetails = model.FileDetails.Select(x => new LandFileDetail()
                    {
                        Id = x.Id,
                        Extension = x.Extension,
                        FileName = x.FileName
                    }).ToList();

                    _landRepository.Update(db);
                }
            }
        }

        public LandServiceModel GetById(int id)
        {
            var data = _landRepository.GetById(id);
            if (data == null)
                return null;

            var vm = ParseToLandServiceModel(data);
            return vm;
        }

        private static LandServiceModel ParseToLandServiceModel(Land data)
        {
            var vm = new LandServiceModel()
            {
                Id = data.ID,
                IsActive = data.IsActive,
                Name = data.Name,
                ThumbPath = data.ThumbPath,
                CreatedDateTime = data.CreatedDate,
                Description = data.Description,
                UpdatedDateTime = data.UpdatedDate,
                IsInVitrin = data.Vitrin,
                ExpertId = data.ExpertID,
                Expert = data.Expert,
                Price = data.Price,
                Size = data.Size,
                AdaNo = data.AdaNo,
                Emsal = data.Kaks,
                Gabari = data.Gabari,
                ImarId = data.ImarID,
                Imar = data.Imar.Name,
                KatKarsiligi = data.KatKarsiligi,
                KimdenId = data.KimdenID,
                Kimden = data.Kimden.Name,
                KrediId = data.KrediID,
                Kredi = data.Kredi.Name,
                KurlarId = data.KurlarID,
                Kur = data.Kurlar.Name,
                PaftaNo = data.PaftaNo,
                ParselNo = data.ParselNo,
                PriceForM2 = data.SizePrice,
                StatusId = data.StatusID,
                Status = data.Status.Name,
                Takas = data.Takas,
                TapuDurumu = data.Tapu,
                Semt = data.Semt.Ad,
                Ilce = data.Semt.Ilce.Ad,
                Il = data.Semt.Ilce.Il.Ad,
                SemtId = data.SemtID,
                IlId=data.Semt.Ilce.IlID,
                IlceId=data.Semt.IlceID,
                FileDetails = data.LandFileDetails.Select(x => new FileDetailServiceModel()
                {
                    Id = x.Id,
                    Extension = x.Extension,
                    FileName = x.FileName
                }).ToList()
            };
            return vm;
        }

        public LandServiceModel GetActiveRecordById(int id)
        {
            var data = _landRepository.Table.SingleOrDefault(x => x.IsActive && x.ID == id);
            if (data == null)
                return null;

            var vm = ParseToLandServiceModel(data);
            return vm;
        }

        public void DeleteById(int id)
        {
            _landRepository.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            var model = _landRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _landRepository.Update(model);
            }
        }

        public IList<LandServiceModel> GetAll()
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

        public IList<LandServiceModel> Get(Expression<Func<LandServiceModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            var model = _landRepository.GetById(id);
            if (model != null)
            {
                model.Vitrin = !model.Vitrin;
                _landRepository.Update(model);
            }
        }
    }
}
