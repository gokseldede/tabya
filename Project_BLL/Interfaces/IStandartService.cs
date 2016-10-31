using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project_BLL.Interfaces
{
    public interface IStandartService<T>
    {
        void Create(T model);
        void edit(T model);
        T GetById(int Id);
        void DeleteById(int Id);
        void ChangeStatus(int Id);
        IList<T> GetAll();
        IList<T> Get(Expression<Func<T, bool>> predicate);
    }
}
