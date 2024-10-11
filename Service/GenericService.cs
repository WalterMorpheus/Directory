using Interface;

namespace Service
{
    public class GenericService<T, TKey> : IGenericService<T, TKey> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<T> GetByIdAsync(TKey id)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            return await repository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            return await repository.GetAllAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            var addedEntity = await repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return addedEntity;
        }
        public async Task UpdateAsync(T entity)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            await repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(TKey id)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            await repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
