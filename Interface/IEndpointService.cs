using Microsoft.AspNetCore.Mvc;

namespace Interface
{
    public interface IEndpointService<TDto>
        where TDto : class
    {
        Task<ActionResult<bool>> AddAsync(TDto dto);
        Task<ActionResult<IEnumerable<TDto>>> ListAsync();
        Task<ActionResult<bool>> UpdateAsync(TDto dto);
        Task<ActionResult> GetByAlternateID(Guid id);
    }
}
