using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project_BLL.Interfaces
{
    public interface IStandartService<T>
    {
        void Create(T model);
        void Edit(T model);
        T GetById(int id);
        T GetActiveRecordById(int id);
        void DeleteById(int id);
        void ChangeStatus(int id);
        IList<T> GetAll();
        IList<T> Get(Expression<Func<T, bool>> predicate);
        void ChangeVitrin(int id);
    }
}
