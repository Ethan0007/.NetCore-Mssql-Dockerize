using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SampleApis.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
    }
}
