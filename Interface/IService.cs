using Shared.DTOs;

namespace Interface 
{
    public interface IService<TDto>
        where TDto : class
    {
        Task<bool> Add(TDto dto);
        Task<TDto> Get(int id);
        Task<IEnumerable<TDto>> List();
        Task<bool> Update(TDto dto);
    }
}
