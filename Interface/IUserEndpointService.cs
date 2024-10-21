using Microsoft.AspNetCore.Mvc;

namespace Interface
{
    public interface IUserEndpointService<TDto>
        where TDto : class
    {
        Task<ActionResult<object>> LoginAsync(TDto dto);
        Task<ActionResult<object>> RegisterAsync(TDto dto);
    }
}
