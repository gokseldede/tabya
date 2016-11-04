using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_BLL.Implementation
{
    public class StandartService<T> : IStandartService<T> where T : EntityBase, new()
    {
        private readonly IRepository<T> _repository;
        public StandartService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void ChangeStatus(int id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                entity.IsActive = !entity.IsActive;
                _repository.Update(entity);
            }
        }

        public void Create(T model)
        {
            if (model != null)
                _repository.Insert(model);
        }

        public void DeleteById(int id)
        {
            _repository.Delete(id);
        }

        public void Edit(T model)
        {
            if (model != null)
            {
                var orginalRecord = GetById(model.ID);
                var name = orginalRecord.GetType().GetProperty("Name");
                name.SetValue(orginalRecord, model.GetType().GetProperty("Name").GetValue(model));
                _repository.Update(orginalRecord);
            }
        }

        public IList<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _repository.Table.Where(predicate).ToList();
        }

        public void ChangeVitrin(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return _repository.Table.Where(x => x.IsDelete == false).ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
