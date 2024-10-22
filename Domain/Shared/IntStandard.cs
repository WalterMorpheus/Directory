namespace Domain.Shared
{
    public class IntStandard
    {
        public int Id { get; set; }
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
