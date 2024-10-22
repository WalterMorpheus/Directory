namespace Domain.Shared
{
    public class Standard
    {
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        public Guid UserAlternateId { get; set; } = Guid.Parse("677ee02d-8207-46ac-bfc9-2b234d9461d0");
    }
}
