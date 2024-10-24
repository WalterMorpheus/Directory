using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public class Repository<TDto, TEntity, TKey> : IRepository<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        public Repository(DbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }
        public async Task<TDto> AddAsync(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
        public async Task<TDto> GetByIdAsync(TKey id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;
            return _mapper.Map<TDto>(entity);
        }
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByReferenceAsync(Expression<Func<TDto, bool>> predicate)
        {
            var entityPredicate = _mapper.MapExpression<Expression<Func<TEntity, bool>>>(predicate);
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            query = query.IncludeRelatedEntities<TEntity, TDto>();

            var entity = await query.FirstOrDefaultAsync(entityPredicate);
            return _mapper.Map<TDto>(entity);
        }


        public async Task<IEnumerable<TDto>> GetListByParametersAsync(Expression<Func<TDto, bool>> predicate)
        {
            var entityPredicate = _mapper.MapExpression<Expression<Func<TEntity, bool>>>(predicate);
            var entities = await _dbSet.Where(entityPredicate).ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        public async Task<TDto> UpdateAsync(TDto dto)
        {
            string username = typeof(TDto).GetProperty("UserAlternateId")?.GetValue(dto)?.ToString();
            Guid alternateId = Guid.Parse(typeof(TDto).GetProperty("AlternateId")?.GetValue(dto)?.ToString());

            if (string.IsNullOrEmpty(username))
            {
                throw new InvalidOperationException("User cannot be null or empty.");
            }
            TEntity entity = await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "AlternateId").Equals(alternateId));
            if (entity == null)
            {
                throw new InvalidOperationException($"Entity with alternateId = {alternateId} was not found.");
            }
            _mapper.Map(dto, entity);

            EntityEntry trackedEntity = _context.Entry(entity);
            trackedEntity.Property("UpdateDate").CurrentValue = DateTime.UtcNow;
            trackedEntity.Property("UpdateBy").CurrentValue = username;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
        public async Task DeleteAsync(TKey id)
        {
            TEntity entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
