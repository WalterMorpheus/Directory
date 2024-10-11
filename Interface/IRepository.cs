using System.Linq.Expressions;

namespace Interface
{
    public interface IRepository<T, TKey> where T : class
    {
        /*Create*/
        Task<T> AddAsync(T entity);
        /*Read*/
        Task<T> GetByIdAsync(TKey id);
        Task<T> GetByReferenceAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetListByParametersAsync(Expression<Func<T, bool>> predicate);
        /*Update*/
        Task UpdateAsync(T entity);
        /*Delete*/
        Task DeleteAsync(TKey id);
    }
}
