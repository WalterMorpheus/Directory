using Data.Entity.Core;
using Domain.DTOs;
using Interface;

namespace Service.Services.Core
{
    public class Service<TDto> : IService<TDto> where TDto : class
    {
        private readonly IGenericService<TDto, TEntity, int> _genericService;

        public Service(IGenericService<TDto, TEntity, int> genericService)
        {
            _genericService = genericService;
        }

        public Task<bool> Add(TDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDto>> list()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TDto dto)
        {
            throw new NotImplementedException();
        }


        //public async Task<bool> Add(TDto dto)
        //{
        //    return await _applicationService.AddAsync(dto) != null;
        //}
        //public async Task<TDto> Get(int id)
        //{
        //    return await _applicationService.GetByIdAsync(id);
        //}
        //public async Task<IEnumerable<TDto>> list()
        //{
        //    return await _applicationService.GetAllAsync();
        //}
        //public async Task<bool> Update(TDto dto)
        //{
        //    return await _applicationService.UpdateAsync(dto) != null;
        //}
    }
}
