﻿using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL.Implementation
{
    public class StandartService<T> : IStandartService<T> where T : EntityBase, new()
    {
        private readonly IRepository<T> _repository;
        public StandartService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void ChangeStatus(int Id)
        {
            T entity = GetById(Id);
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

        public void DeleteById(int Id)
        {
            _repository.Delete(Id);
        }

        public void edit(T model)
        {
            if (model != null)
            {
                var orginalRecord = GetById(model.ID);
                var name = orginalRecord.GetType().GetProperty("Name");
                name.SetValue(orginalRecord, model.GetType().GetProperty("Name").GetValue(model));
                _repository.Update(orginalRecord);
            }
        }

        public IList<T> GetAll()
        {
            return _repository.Table.Where(x => x.IsDelete == false).ToList();
        }

        public T GetById(int Id)
        {
            return _repository.GetById(Id);
        }
    }
}
