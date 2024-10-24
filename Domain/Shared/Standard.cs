namespace Domain.Shared
{
    public class Standard
    {
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid UserAlternateId { get; set; }

    }
}
