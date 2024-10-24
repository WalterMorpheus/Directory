using Domain.Entity.Core;
using Domain.Shared;

namespace Domain.DTOs.External
{
    public class ApplicationDto : Standard
    {
        public int Id { get; set; }
        public ICollection<UserCustomerApplicationDto> UserCustomerApplications { get; set; }
    }
}


