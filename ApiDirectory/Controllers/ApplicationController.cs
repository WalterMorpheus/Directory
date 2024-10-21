using ApiDirectory.Controllers;
using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

[Authorize]
public class ApplicationController : BaseApiController, IEndpointService<ApplicationDto>
{
    private readonly IService<ApplicationDto> _service;

    public ApplicationController(IService<ApplicationDto> service)
    {
        _service = service;
    }
    [HttpPost("add")]
    public async Task<ActionResult<bool>> AddAsync(ApplicationDto dto)
    {
        return await _service.Add(dto);
    }
    [AllowAnonymous]
    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ApplicationDto>>> ListAsync()
    {
        return new ActionResult<IEnumerable<ApplicationDto>>(await _service.List());
    }
    [HttpGet("get/{id}")]
    public async Task<ActionResult<ApplicationDto>> GetAsync(int id)
    {
        return await _service.Get(id);
    }
    [HttpPost("update")]
    public async Task<ActionResult<bool>> UpdateAsync(ApplicationDto dto)
    {
        return await _service.Update(dto);
    }
    public Task<ActionResult> GetByAlternateID(Guid id)
    {
        throw new NotImplementedException();
    }
}
