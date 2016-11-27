using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;

namespace Project_BLL.Implementation
{
    public class AdminUserService : IStandartService<AdminUser>
    {
        private readonly IRepository<AdminUser> _adminUserRepository;

        public AdminUserService()
        {
            _adminUserRepository = new EfRepositoryForEntityBase<AdminUser>();
        }

        public void Create(AdminUser model)
        {
            _adminUserRepository.Insert(model);
        }

        public void Edit(AdminUser model)
        {
            _adminUserRepository.Update(model);
        }

        public AdminUser GetById(int id)
        {
            return _adminUserRepository.GetById(id);
        }

        public AdminUser GetActiveRecordById(int id)
        {
            return _adminUserRepository.Table.SingleOrDefault(x => x.IsActive && x.ID == id);
        }

        public void DeleteById(int id)
        {
            _adminUserRepository.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            var model = _adminUserRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _adminUserRepository.Update(model);
            }
        }

        public IList<AdminUser> GetAll()
        {
            return _adminUserRepository.Table.Where(x => x.IsDelete == false).ToList();
        }

        public IList<AdminUser> Get(Expression<Func<AdminUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            throw new NotImplementedException();
        }
    }
}