namespace Domain.Auth
{
    public class UserClaims
    {
        public Guid UserAlternateId { get; set; }  
        public Guid ApplicationAlternateId { get; set; }
        public Guid CustomerAlternateId { get; set; }
    }
}
