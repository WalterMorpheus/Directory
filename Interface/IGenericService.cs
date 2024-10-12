namespace Interface
{
    public interface IGenericService<T, TKey> where T : class
    {
        Task<TDto> AddAsync<TDto>(TDto dto);

        Task<TDto> GetByIdAsync<TDto>(TKey id);

        Task<IEnumerable<TDto>> GetAllAsync<TDto>();

        Task<TDto> UpdateAsync<TDto>(TDto dto);

        Task DeleteAsync(TKey id);
    }
}
