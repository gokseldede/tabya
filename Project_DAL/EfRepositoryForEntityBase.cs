using Project_Entity;
using System;
using System.Data.Entity;
using System.Linq;

namespace Project_DAL
{
    public class EfRepositoryForEntityBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        private readonly DbContext _context;
        private IDbSet<TEntity> _entities;

        public EfRepositoryForEntityBase()
        {
            _context = new ProjectContext();
        }

        public EfRepositoryForEntityBase(DbContext context)
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
            var entity = GetById(id);
            if (entity != null)
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

        IQueryable<TEntity> IRepository<TEntity>.Table => Entities;
    }
}
