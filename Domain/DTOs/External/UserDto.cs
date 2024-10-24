namespace Domain.DTOs.External
{
    public class UserDto
    {
        public Guid AlternateId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
        public ICollection<UserCustomerApplicationDto> UserCustomerApplications { get; set; }
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
