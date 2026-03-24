using System.Diagnostics;

namespace UserManagementAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;
            
            _logger.LogInformation($"[Request] {method} {path}");

            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            var statusCode = context.Response.StatusCode;
            _logger.LogInformation($"[Response] {method} {path} => Status: {statusCode} (Finalizado em {stopwatch.ElapsedMilliseconds}ms)");
        }
    }
}