using Domain.Entity.Core;
using Domain.Shared;

namespace Domain.DTOs.External
{
    public class CustomerDto: Standard
    {
        public ICollection<UserCustomerDto> UserCustomers { get; set; }
        public ICollection<CustomerApplicationDto> CustomerApplications { get; set; }
    }
}
