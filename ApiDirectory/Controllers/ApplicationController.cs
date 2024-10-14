using Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace ApiDirectory.Controllers
{
    public class ApplicationController : BaseApiController, IEndpointService<ApplicationDto>
    {
        [HttpGet("add")]
        public Task<ActionResult<bool>> AddAsync(ApplicationDto dto)
        {
            throw new NotImplementedException();
        }
        [HttpGet("get")]
        public Task<ActionResult<ApplicationDto>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
