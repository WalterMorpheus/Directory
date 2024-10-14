using Microsoft.AspNetCore.Mvc;

namespace Interface
{
    public interface IEndpointService<TDto>
        where TDto : class
    {
        Task<ActionResult<TDto>> GetAsync(int id);
        Task<ActionResult<bool>> AddAsync(TDto dto);
    }
}
