using Interface;
using Shared.DTOs;
using System.Net;
using System.Text.Json;

namespace ApiDirectory.Middleware
{
    public class ApiException
    {
        public ApiException(int statusCode, string message, string details)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IException exHandler;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env, IServiceScopeFactory scopeFactory,
            IException exHandler)
        {
            _env = env;
            _logger = logger;
            _next = next;
            _scopeFactory = scopeFactory;
            this.exHandler = exHandler;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await exHandler.ExceptionLogAsync(new ExceptionLogDto
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.UtcNow,
                    Request = $"{context.Request.Method}; {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
                    HResult = ex.HResult
                });

                ApiException response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

                JsonSerializerOptions options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                string json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
