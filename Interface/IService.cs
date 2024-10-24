using System.Linq.Expressions;

namespace Interface 
{
    public interface IService<TDto>
        where TDto : class
    {
        Task<bool> Add(TDto dto);
        Task<TDto> Get(int id);
        Task<TDto> GetByReferenceAsync(Expression<Func<TDto, bool>> predicate);
        Task<IEnumerable<TDto>> List();
        Task<bool> Update(TDto dto);
    }
}
