namespace Shared.DTOs
{
    public class UserDto
    {
       public Guid AlternateId { get; set; }
       public string UserName { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
    }
}
