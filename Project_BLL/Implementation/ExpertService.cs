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

        public void ChangeStatus(int id)
        {
            Expert expert = GetById(id);
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

        public void DeleteById(int id)
        {
            _expertRepository.Delete(id);
        }

        public void Edit(Expert model)
        {
            if (model != null)
                _expertRepository.Update(model);
        }

        public IList<Expert> Get(System.Linq.Expressions.Expression<Func<Expert, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            throw new NotImplementedException();
        }


        public IList<Expert> GetAll()
        {
            return _expertRepository.Table.Where(x => x.IsDelete == false).ToList();
        }

        public Expert GetById(int id)
        {
            return _expertRepository.GetById(id);
        }
    }
}
