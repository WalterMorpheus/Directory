﻿namespace Shared.DTOs
{
    public class UserDto
    {
       public string UserName { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public string CustomerName { get; set; }
       public Guid ApplicationAlternateId { get; set; }
    }
}
