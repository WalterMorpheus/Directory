using Shared.DTOs;

namespace Interface
{
    public interface IApplicationService
    {
        Task<bool> Add(ApplicationDto dto);
        Task<ApplicationDto> Get(int id);
        Task<IEnumerable<ApplicationDto>> list();
        Task<bool> Update(ApplicationDto dto);
    }
}
