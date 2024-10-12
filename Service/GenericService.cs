using AutoMapper;
using Interface;

namespace Service
{
    public class GenericService<T, TKey> : IGenericService<T, TKey> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TDto> AddAsync<TDto>(TDto dto)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            var entity = _mapper.Map<T>(dto);
            var addedEntityDto = await repository.AddAsync<TDto>(entity);
            return addedEntityDto;
        }

        public async Task<TDto> GetByIdAsync<TDto>(TKey id)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            var entityDto = await repository.GetByIdAsync<TDto>(id);
            return entityDto;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync<TDto>()
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            var entityDtos = await repository.GetAllAsync<TDto>();
            return entityDtos;
        }

        public async Task<TDto> UpdateAsync<TDto>(TDto dto)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            var entity = _mapper.Map<T>(dto);
            var updatedEntityDto = await repository.UpdateAsync<TDto>(entity);
            return updatedEntityDto;
        }

        public async Task DeleteAsync(TKey id)
        {
            var repository = _unitOfWork.GetRepository<T, TKey>();
            await repository.DeleteAsync(id);
        }
    }
}
