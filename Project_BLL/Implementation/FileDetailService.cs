using System;
using System.Linq;
using Project_BLL.Interfaces;
using Project_BLL.ViewModels;
using Project_DAL;
using Project_Entity;

namespace Project_BLL.Implementation
{
    public class FileDetailService<T> : IFileService<T> where T : BaseFileDetail, new()
    {
        private readonly IRepository<T> _fileRepository;

        public FileDetailService()
        {
            _fileRepository = new EfRepository<T>();
        }
        public FileDetailServiceModel GetById(Guid id)
        {
            return _fileRepository.Table.Where(x => x.Id == id).Select(x => new FileDetailServiceModel() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).FirstOrDefault();
        }

        public void DeleteById(Guid id)
        {
            var model = _fileRepository.Table.FirstOrDefault(x => x.Id == id);
            _fileRepository.Delete(model);
        }
    }
}
