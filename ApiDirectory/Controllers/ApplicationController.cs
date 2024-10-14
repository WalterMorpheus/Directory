using ApiDirectory.Controllers;
using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

[Authorize]
public class ApplicationController : BaseApiController, IEndpointService<ApplicationDto>
{
    private readonly IApplicationService _applicationServiceService;

    public ApplicationController(IApplicationService applicationServiceService)
    {
        _applicationServiceService = applicationServiceService;
    }
    [HttpPut("add")]
    public async Task<ActionResult<bool>> AddAsync(ApplicationDto dto)
    {
        return await _applicationServiceService.Add(dto);
    }
    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<ApplicationDto>>> listAsync()
    {
        return new ActionResult<IEnumerable<ApplicationDto>>(await _applicationServiceService.list());
    }
    [HttpGet("get")]
    public async Task<ActionResult<ApplicationDto>> GetAsync(int id)
    {
        return await _applicationServiceService.Get(id);
    }
    [HttpGet("update")]
    public async Task<ActionResult<bool>> UpdateAsync(ApplicationDto dto)
    {
        return await _applicationServiceService.Update(dto);
    }
}
