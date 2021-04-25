using Microsoft.EntityFrameworkCore;
using SampleApis.Data.Entities;
using SampleApis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SampleApis.Services.CRUD
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SystemsDbContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        public Repository(SystemsDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public TEntity Get(Guid id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
      
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }


        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }
    }
}
