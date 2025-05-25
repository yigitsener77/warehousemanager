using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public interface IRepository<T> where T : class
    {
        //Async yapıda void yerine Task yazılır.
        Task CreateAsync(T entity);
        //Return type ile Task<T> vb şekilde generic yazılır.
        Task<T> ReadOneAsync(object entityKey);
        Task<T> ReadFirstAsync(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>> expression = null, params string[] includes);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> expression = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression = null);
    }
}
