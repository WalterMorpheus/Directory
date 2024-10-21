using AutoMapper;
using Data;
using Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Helper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(DataContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            _context = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public IRepository<TDto, TEntity, TKey> GetRepository<TDto, TEntity, TKey>()
            where TDto : class
            where TEntity : class
        {
            return ActivatorUtilities.CreateInstance<Repository<TDto, TEntity, TKey>>(
                _serviceProvider, _context, _mapper);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
