namespace Interface
{
    public interface IUserService<TDto>
        where TDto : class
    {
        Task<string> login(TDto dto);
        Task<string> Register(TDto dto);      
    }
}
