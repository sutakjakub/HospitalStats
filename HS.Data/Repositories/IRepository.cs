using HS.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Data.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
        void Update(T entity);

    }
}
