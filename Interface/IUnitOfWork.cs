namespace Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T, TKey> GetRepository<T, TKey>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
