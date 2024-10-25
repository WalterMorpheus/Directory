using ApiDirectory.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Core;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class BaseGenericController<TDto> : ControllerBase where TDto : class
{
    protected readonly GenericService<TDto> _service;

    public BaseGenericController(GenericService<TDto> service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public virtual async Task<ActionResult<bool>> AddAsync(TDto dto)
    {
        return await _service.Add(dto);
    }
    [AllowAnonymous]
    [HttpGet("list")]
    public virtual async Task<ActionResult<IEnumerable<TDto>>> ListAsync()
    {
        return new ActionResult<IEnumerable<TDto>>(await _service.List());
    }

    [HttpGet("get/{id}")]
    public virtual async Task<ActionResult<TDto>> GetAsync(int id)
    {
        return await _service.Get(id);
    }

    [HttpPost("update")]
    public virtual async Task<ActionResult<bool>> UpdateAsync(TDto dto)
    {
        return await _service.Update(dto);
    }

}
