using System.Collections.Generic;

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
    }
}
