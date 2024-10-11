using System.Linq.Expressions;
using Interface;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {       
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T model)
        {
            await _dbSet.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByReferenceAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListByParametersAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task UpdateAsync(T model)
        {
            _dbSet.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var model = await GetByIdAsync(id);
            if (model != null)
            {
                _dbSet.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

    }

}
