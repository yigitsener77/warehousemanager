using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _db;
        protected readonly DbSet<T> _set;

        protected Repository(DbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
            {
                return await _set.AnyAsync(expression, CancellationToken.None);
            }
            else
            {
                return await _set.AnyAsync();
            }
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
            {
                return await _set.CountAsync(expression);
            }
            else
            {
                return await _set.CountAsync();
            }
        }

        public virtual async Task CreateAsync(T entity)
        {
            await Task.Run(() => _set.Add(entity));
        }

        public virtual async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _set.Remove(entity));
        }

        public virtual async Task<T> ReadFirstAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
            {
                return await _set.FirstOrDefaultAsync(expression);
            }
            else
            {
                return await _set.FirstOrDefaultAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>> expression = null, params string[] includes)
        {
            IQueryable<T> data = expression != null ? _set.Where(expression) : _set;

            foreach (var include in includes)
            {
                data = data.Include(include);
            }

            return await data.ToListAsync();
        }

        public virtual async Task<T> ReadOneAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _db.Entry(entity).State = EntityState.Modified);
        }
    }
}
