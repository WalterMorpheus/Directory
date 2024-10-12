using System.Linq.Expressions;

namespace Interface
{
    public interface IRepository<T, TKey> where T : class
    {
        Task<TDto> AddAsync<TDto>(T entity);
        Task<TDto> GetByIdAsync<TDto>(TKey id);
        Task<TDto> GetByReferenceAsync<TDto>(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<TDto>> GetAllAsync<TDto>();
        Task<IEnumerable<TDto>> GetListByParametersAsync<TDto>(Expression<Func<T, bool>> predicate);
        Task<TDto> UpdateAsync<TDto>(T entity);
        Task DeleteAsync(TKey id);
    }
}
