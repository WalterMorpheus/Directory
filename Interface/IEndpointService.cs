using Microsoft.AspNetCore.Mvc;
using Shared.Shared;

namespace Interface
{
    public interface IEndpointService<TDto>
        where TDto : Standard
    {
        Task<ActionResult<bool>> AddAsync(TDto dto);
        Task<ActionResult<IEnumerable<TDto>>> listAsync();
        Task<ActionResult<bool>> UpdateAsync(TDto dto);
        Task<ActionResult> GetByAlternateID(Guid id);
    }
    public abstract class GenpointService<Domain, Entity, Key> : IEndpointService<Domain>
        where Domain : Standard
        where Entity : class
    {
        private readonly IRepository<Domain, Entity, Key> repository;

        public GenpointService(IRepository<Domain, Entity, Key> repository)
        {
            this.repository = repository;
        }
        public async Task<ActionResult<bool>> AddAsync(Domain dto)
        {
            var addedItem = await repository.AddAsync(dto);
            if (addedItem == null)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(true);
        }
        public async Task<ActionResult> GetByAlternateID(Guid id)
        {
            var item = await repository.GetByReferenceAsync(x => x.AlternateId == id);
            if (item == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(item);
        }
        public async Task<ActionResult<IEnumerable<Domain>>> listAsync()
        {
            var items = await repository.GetAllAsync();
            if (items == null || !items.Any())
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(items);
        }
        public async Task<ActionResult<bool>> UpdateAsync(Domain dto)
        {
            var updatedItem = await repository.UpdateAsync(dto);
            if (updatedItem == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(true);
        }
    }
}
