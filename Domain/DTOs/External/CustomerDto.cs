using Domain.Entity.Core;
using Domain.Shared;

namespace Domain.DTOs.External
{
    public class CustomerDto: Standard
    {
        public ICollection<UserCustomerApplicationDto> UserCustomerApplications { get; set; }
    }
}
