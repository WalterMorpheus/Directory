using AutoMapper;
using Interface;
using Service.Extensions;
using Service.MappingProfiles;
using System.Linq.Expressions;

namespace Service.Services.Core
{

    public class GenericService<TDto> : IService<TDto>
        where TDto : class
    {
        private readonly IMapper _mapper;
        private readonly TokenClaims _tokenClaims;
        private readonly IUnitOfWork _unitOfWork;
        private readonly MappingProvider _mappingProvider;

        public GenericService(IMapper mapper, TokenClaims tokenClaims, IUnitOfWork unitOfWork, MappingProvider mappingProvider)
        {
            _mapper = mapper;
            _tokenClaims = tokenClaims;
            _unitOfWork = unitOfWork;
            _mappingProvider = mappingProvider;
        }

        private object GetEntityServiceForType(Type entityType)
        {
            var method = _unitOfWork
                .GetType()
                .GetMethod("GetRepository")
                .MakeGenericMethod(typeof(TDto), entityType, typeof(int));

            return method.Invoke(_unitOfWork, null);
        }
        public async Task<bool> Add(TDto dto)
        {
            var entityType = _mappingProvider.GetEntityType<TDto>();
            var repository = GetEntityServiceForType(entityType);

            var addMethod = repository.GetType().GetMethod("AddAsync");
            var task = (Task)addMethod.Invoke(repository, new[] { dto });
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");

            if (resultProperty.GetValue(task) == null) return false;
            return  true;
        }
        public async Task<TDto> Get(int id)
        {
            var entityType = _mappingProvider.GetEntityType<TDto>();
            var repository = GetEntityServiceForType(entityType);
            var getMethod = repository.GetType().GetMethod("GetByIdAsync");

            // Invoke the GetByIdAsync method dynamically and await its result
            var task = (Task)getMethod.Invoke(repository, new object[] { id });
            await task.ConfigureAwait(false);

            // Get the result from the task dynamically
            var resultProperty = task.GetType().GetProperty("Result");
            var entity = resultProperty.GetValue(task);

            // Map the entity to TDto using AutoMapper
            return (TDto)_mapper.Map(entity, entityType, typeof(TDto));
        }
        public async Task<IEnumerable<TDto>> List()
        {
            var entityType = _mappingProvider.GetEntityType<TDto>();
            var repository = GetEntityServiceForType(entityType);

            var listMethod = repository.GetType().GetMethod("GetAllAsync");

            // Invoke the method and cast the result dynamically
            var task = (Task)listMethod.Invoke(repository, null);
            // Await the task to ensure the method completes
            await task.ConfigureAwait(false);

            // Use reflection to get the result of the task (as IEnumerable<object>)
            var resultProperty = task.GetType().GetProperty("Result");
            var entities = (IEnumerable<object>)resultProperty.GetValue(task);

            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        public async Task<bool> Update(TDto dto)
        {

            var entityType = _mappingProvider.GetEntityType<TDto>();

            var repository = GetEntityServiceForType(entityType);
            var updateMethod = repository.GetType().GetMethod("UpdateAsync");

            var task = (Task)updateMethod.Invoke(repository, new[] { dto });

            
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            if (resultProperty.GetValue(task) == null) return false;
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var entityType = _mappingProvider.GetEntityType<TDto>();
            var repository = GetEntityServiceForType(entityType);

            var deleteMethod = repository.GetType().GetMethod("DeleteAsync");
            await (Task<object>)deleteMethod.Invoke(repository, new object[] { id });

            var changesSaved = await _unitOfWork.SaveChangesAsync();
            return changesSaved > 0;
        }
        public async Task<TDto> GetByReferenceAsync(Expression<Func<TDto, bool>> predicate)
        {
            var entityType = _mappingProvider.GetEntityType<TDto>();
            var repository = GetEntityServiceForType(entityType);
            var getReferenceMethod = repository.GetType().GetMethod("GetByReferenceAsync");

            var task = (Task)getReferenceMethod.Invoke(repository, new object[] { predicate });

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            var entity = resultProperty.GetValue(task);

            return (TDto)_mapper.Map(entity, entityType, typeof(TDto));
        }
    }

}
