using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Project_BLL.Interfaces;
using Project_DAL;
using Project_Entity;

namespace Project_BLL.Implementation
{
    public class ContanctService : IStandartService<Contact>
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContanctService()
        {
            _contactRepository = new EfRepositoryForEntityBase<Contact>();
        }

        public void Create(Contact model)
        {
            _contactRepository.Insert(model);
        }

        public void Edit(Contact model)
        {
            var db = _contactRepository.GetById(model.ID);

            db.Email = model.Email;
            db.Maps = model.Maps;
            db.Name = model.Name;
            db.Number = model.Number;
           _contactRepository.Update(db);
        }

        public Contact GetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public void DeleteById(int id)
        {
           _contactRepository.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            var model = _contactRepository.GetById(id);
            if (model != null)
            {
                model.IsActive = !model.IsActive;
                _contactRepository.Update(model);
            }
        }

        public IList<Contact> GetAll()
        {
            return _contactRepository.Table.ToList();
        }

        public IList<Contact> Get(Expression<Func<Contact, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void ChangeVitrin(int id)
        {
            throw new NotImplementedException();
        }
    }
}