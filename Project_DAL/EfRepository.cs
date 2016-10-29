﻿using Project_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Project_DAL
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        private readonly DbContext _context;
        private IDbSet<TEntity> _entities;

        public EfRepository()
        {
            _context = new ProjectContext();
        }

        public EfRepository(DbContext context)
        {
            _context = context;
        }

        private IDbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = _context.Set<TEntity>()); }
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.UpdatedDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {

            entity.UpdatedDate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = new TEntity
            {
                ID = id
            };

            Entities.Attach(entity);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.IsActive = false;
            entity.Vitrin = false;
            entity.IsDelete = true;
            entity.DeletedDate = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IList<TEntity> Table
        {
            get { return Entities.ToList(); }
        }
    }
}