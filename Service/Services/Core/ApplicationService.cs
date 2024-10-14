using Domain.Entity.Core;
using Interface;
using Shared.DTOs;

namespace Service.Services.Core
{
    public class ApplicationService : IApplicationService
    {
        private readonly IGenericService<ApplicationDto, Application, int> _applicationService;

        public ApplicationService(IGenericService<ApplicationDto, Application, int> applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task<bool> Add(ApplicationDto dto)
        {
            return await _applicationService.AddAsync(dto) != null;
        }
        public async Task<ApplicationDto> Get(int id)
        {
            return await _applicationService.GetByIdAsync(id);
        }
    }
}
