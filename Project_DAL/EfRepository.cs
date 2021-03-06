﻿using System;
using System.Data.Entity;
using System.Linq;
using Project_Entity;

namespace Project_DAL
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
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
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        IQueryable<TEntity> IRepository<TEntity>.Table => Entities;
    }
}