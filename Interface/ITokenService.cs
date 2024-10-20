namespace Interface
{
    public interface ITokenService<TDto>
        where TDto : class
    {
        Task<string> CreateToken(TDto dto);
    }
}
