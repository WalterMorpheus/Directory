using Interface;
using System.Linq.Expressions;

namespace Service
{
    public class GenericService<TDto, TEntity, TKey> : IGenericService<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            return await repository.GetAllAsync();
        }

        public async Task<TDto> GetByIdAsync(TKey id)
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            return await repository.GetByIdAsync(id);
        }

        public async Task<TDto> GetByReferenceAsync(Expression<Func<TDto, bool>> predicate)
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            return await repository.GetByReferenceAsync(predicate);
        }

        public async Task<IEnumerable<TDto>> GetListByParametersAsync(Expression<Func<TDto, bool>> predicate)
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            return await repository.GetListByParametersAsync(predicate);
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            return await repository.AddAsync(dto);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            return await repository.UpdateAsync(dto);
        }

        public async Task DeleteAsync(TKey id)
        {
            var repository = _unitOfWork.GetRepository<TDto, TEntity, TKey>();
            await repository.DeleteAsync(id);
        }
    }
}
