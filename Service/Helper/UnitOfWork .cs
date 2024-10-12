using AutoMapper;
using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Helper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;  // Use the specific DataContext
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(DataContext context, IMapper mapper, IServiceProvider serviceProvider)  // Accept DataContext here
        {
            _context = context;  // Assign the correct context
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public IRepository<T, TKey> GetRepository<T, TKey>() where T : class
        {
            // Create a new repository instance with the correct context and mapper
            return ActivatorUtilities.CreateInstance<Repository<T, TKey>>(_serviceProvider, _context, _mapper);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();  // Save changes to the context
        }

        public void Dispose()
        {
            _context.Dispose();  // Dispose the context
        }
    }
}
