using ApiDirectory.Controllers;
using Domain.DTOs;
using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ApplicationController : BaseApiController, IEndpointService<ApplicationDto>
{
    private readonly IService <ApplicationDto> _service;

    public ApplicationController(IService<ApplicationDto> applicationServiceService)
    {
        _service = applicationServiceService;
    }
    [HttpPost("add")]
    public async Task<ActionResult<bool>> AddAsync(ApplicationDto dto)
    {
        return await _service.Add(dto);
    }
    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ApplicationDto>>> ListAsync()
    {
        return new ActionResult<IEnumerable<ApplicationDto>>(await _service.list());
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
}
