namespace Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TDto, TEntity, TKey> GetRepository<TDto, TEntity, TKey>()
            where TDto : class
            where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
