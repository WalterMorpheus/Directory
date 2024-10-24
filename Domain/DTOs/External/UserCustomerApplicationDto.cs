using Domain.Entity.Auth;

namespace Domain.DTOs.External
{
    public class UserCustomerApplicationDto
    {
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ApplicationId { get; set; }
        public ApplicationDto Application { get; set; }
    }
}
