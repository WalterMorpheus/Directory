namespace Interface
{
    public interface IAuthenticationService <TDto>
        where TDto : class
    {
        Task AddAsync(TDto dto);
    }
}
