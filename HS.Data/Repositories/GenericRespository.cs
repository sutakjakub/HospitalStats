using HS.Data.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly HsDbContext _dbContext;
        private IDbSet<T> _dbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;
        public GenericRepository(HsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Remove(T entity)
        {
            entity.IsDeleted = true;
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }
        public void Add(T entity)
        {
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;

            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) throw new ArgumentException($"Položka {id} neexistuje. Nelze smazat.");

            Remove(entity);
        }
    }
}
