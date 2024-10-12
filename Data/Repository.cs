using System.Linq.Expressions;
using AutoMapper;
using Interface;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        public Repository(DbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _mapper = mapper;
        }
        public async Task<TDto> AddAsync<TDto>(T model)
        {
            await _dbSet.AddAsync(model);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(model);
        }
        public async Task<TDto> GetByIdAsync<TDto>(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return default;
            }
            return _mapper.Map<TDto>(entity);
        }
        public async Task<TDto> GetByReferenceAsync<TDto>(Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(predicate);
            return _mapper.Map<TDto>(entity);
        }
        public async Task<IEnumerable<TDto>> GetAllAsync<TDto>()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        public async Task<IEnumerable<TDto>> GetListByParametersAsync<TDto>(Expression<Func<T, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        public async Task<TDto> UpdateAsync<TDto>(T model)
        {
            _dbSet.Update(model);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(model);
        }
        public async Task DeleteAsync(TKey id)
        {
            var model = await _dbSet.FindAsync(id);

            if (model != null)
            {
                _dbSet.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}
