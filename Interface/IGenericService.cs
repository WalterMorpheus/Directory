using System.Linq.Expressions;

namespace Interface
{
    public interface IGenericService<TDto, TEntity, TKey>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(TKey id);
        Task<TDto> GetByReferenceAsync(Expression<Func<TDto, bool>> predicate);
        Task<IEnumerable<TDto>> GetListByParametersAsync(Expression<Func<TDto, bool>> predicate);
        Task<TDto> AddAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task DeleteAsync(TKey id);
    }
}
