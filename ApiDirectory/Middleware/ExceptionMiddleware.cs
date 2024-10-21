using System.Net;
using System.Text.Json;

namespace ApiDirectory.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string errorReference = Guid.NewGuid().ToString();
            string errorMessage = string.Empty;

            try
            {
                await _next(context);
            }
            catch (InvalidOperationException exc)
            {
                errorMessage = exc.Message;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError(exc, $"Error {errorReference}: {exc.Message}");

                if (context.Response.HasStarted) return;
                
                context.Response.ContentType = "application/json";
                string result = JsonSerializer.Serialize(new { reference = errorReference, error = errorMessage });
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred. Please try again.";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError(ex, $"Error {errorReference}: {ex.Message}");

                if (context.Response.HasStarted) return;
                
                context.Response.ContentType = "application/json";
                string result = JsonSerializer.Serialize(new { reference = errorReference, error = errorMessage });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
