using Domain.Entity.Core;
using Interface;
using Shared.DTOs;

namespace Service.Services.Core
{
    public class ApplicationService<TDto> : IService<ApplicationDto> 
        where TDto : class
    {
        private readonly IGenericService<ApplicationDto, Application, int> _genericService;

        public ApplicationService(IGenericService<ApplicationDto, Application, int> applicationService)
        {
            _genericService = applicationService;
        }

        public async Task<bool> Add(ApplicationDto dto)
        {
            return await _genericService.AddAsync(dto) != null;
        }

        public async Task<ApplicationDto> Get(int id)
        {
            return await _genericService.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ApplicationDto>> List()
        {
            return await _genericService.GetAllAsync();
        }

        public async Task<bool> Update(ApplicationDto dto)
        {
            return await _genericService.UpdateAsync(dto) != null;
        }
    }
}
