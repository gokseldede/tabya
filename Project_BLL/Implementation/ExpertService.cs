using System;
using System.Collections.Generic;
using Project_BLL.Interfaces;
using Project_Entity;
using Project_DAL;
using System.Linq;

namespace Project_BLL.Implementation
{
    public class ExpertService : IExpertService
    {
        private readonly IRepository<Expert> _expertRepository;

        public ExpertService(IRepository<Expert> expertRepository)
        {
            _expertRepository = expertRepository;
        }

        public void ChangeStatus(int Id)
        {
            Expert expert = GetById(Id);
            if (expert != null)
            {
                expert.IsActive = !expert.IsActive;
                _expertRepository.Update(expert);
            }
        }

        public void Create(Expert model)
        {
            if (model != null)
                _expertRepository.Insert(model);
        }

        public void DeleteById(int Id)
        {
            _expertRepository.Delete(Id);
        }

        public void edit(Expert model)
        {
            if (model != null)
                _expertRepository.Update(model);
        }

        public IList<Expert> GetAll()
        {
            return _expertRepository.Table.Where(x => x.IsDelete == false).ToList();
        }

        public Expert GetById(int Id)
        {
            return _expertRepository.GetById(Id);
        }
    }
}
