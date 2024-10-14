using Shared.DTOs;

namespace Interface
{
    public interface IApplicationService
    {
        Task<bool> Add(ApplicationDto dto);
        Task<ApplicationDto> Get(int id);
    }
}
