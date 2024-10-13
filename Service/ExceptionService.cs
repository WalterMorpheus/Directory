using Domain.Entity.Miscellaneous;
using Interface;
using Shared.DTOs;

namespace Service
{
    public class ExceptionService : IException
    {
        private readonly IGenericService<ExceptionLogDto,ExceptionLog, int> _exceptionLog;

        public ExceptionService(IGenericService<ExceptionLogDto, ExceptionLog, int> exceptionLog)
        {
            _exceptionLog = exceptionLog;
        }

        public async Task ExceptionLogAsync(ExceptionLogDto exceptionLog)
        {
            await _exceptionLog.AddAsync(exceptionLog);
        }
    }
}
