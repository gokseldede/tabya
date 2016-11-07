using System;
using Project_BLL.ServiceModels;

namespace Project_BLL.Interfaces
{
    public interface IFileService<T>
    {
        FileDetailServiceModel GetById(Guid id);
        void DeleteById(Guid id);
    }
}