using Domain.Entity.Auth;
using Domain.Entity.Miscellaneous;
using Interface;
using Shared.DTOs;

namespace Service
{
    public class ExceptionService : IException
    {
        private readonly IGenericService<ExceptionLog, int> _exceptionLog;

        public ExceptionService(IGenericService<ExceptionLog, int> exceptionLog)
        {
            _exceptionLog = exceptionLog;
        }

        public async Task ExceptionLogAsync(ExceptionLogDto exceptionLog)
        {
            await _exceptionLog.AddAsync(exceptionLog);
        }
    }
}
