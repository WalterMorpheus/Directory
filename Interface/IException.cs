using Shared.DTOs;

namespace Interface
{
    public interface IException
    {
        Task ExceptionLogAsync(ExceptionLogDto exceptionLog);
    }
}
