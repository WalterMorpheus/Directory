using Domain.DTOs.External;
using Interface;
using Service.Helper;

namespace Service.Services.Core
{
    public class ApplicationService<TDto> : IService<ApplicationDto> 
        where TDto : class
    {
        private readonly ServiceManager _services;

        public ApplicationService(ServiceManager services)
        {
            _services = services;
        }

        public async Task<bool> Add(ApplicationDto dto)
        {
            return await _services.ApplicationService.AddAsync(dto) != null;
        }

        public async Task<ApplicationDto> Get(int id)
        {
            return await _services.ApplicationService.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ApplicationDto>> List()
        {
            return await _services.ApplicationService.GetAllAsync();
        }

        public async Task<bool> Update(ApplicationDto dto)
        {
            return await _services.ApplicationService.UpdateAsync(dto) != null;
        }
    }
}
