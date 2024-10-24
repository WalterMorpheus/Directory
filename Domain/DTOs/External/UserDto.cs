namespace Domain.DTOs.External
{
    public class UserDto
    {
        public int ApplictionAlternateId { get; set; }
        public Guid AlternateId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
        public ICollection<UserCustomerDto> UserCustomers { get; set; }
    }
    public class UserRoleDto
    {
        public UserDto User { get; set; }
        public RoleDto Role { get; set; }
    }
    public class RoleDto 
    {
        public Guid AlternateId { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
    }
}
