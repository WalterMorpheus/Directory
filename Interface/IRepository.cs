using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Interface
{
    public interface IRepository<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : class
    {
        Task<TDto> AddAsync(TDto dto);
        Task<TDto> GetByIdAsync(TKey id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByReferenceAsync(Expression<Func<TDto, bool>> predicate);
        Task<IEnumerable<TDto>> GetListByParametersAsync(Expression<Func<TDto, bool>> predicate);
        Task<TDto> UpdateAsync(TDto dto);
        Task DeleteAsync(TKey id);
    }
}
