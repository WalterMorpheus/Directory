

using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace ApiDirectory.Controllers
{
    [Authorize]
    public class ApplicationController : BaseApiController
    {
        private readonly IEndpointService<ApplicationDto> _endpointService;
        public ApplicationController(IEndpointService<ApplicationDto> endpointService)
        {
            _endpointService = endpointService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ApplicationDto dto)
        {
            var result = await _endpointService.AddAsync(dto);
            return result.Result;
        }
        [HttpGet("get{id}")]
        public async Task<IActionResult> GetByAlternateId(Guid id)
        {
            var result = await _endpointService.GetByAlternateID(id);
            return result;
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _endpointService.listAsync();
            return result.Result;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ApplicationDto dto)
        {
            var result = await _endpointService.UpdateAsync(dto);
            return result.Result;
        }
    }
}



