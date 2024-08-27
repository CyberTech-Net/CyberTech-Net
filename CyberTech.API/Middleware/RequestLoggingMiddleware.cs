using Serilog;
using System.Text;

namespace CyberTech.API.Middleware
{
    public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            var httpMethod = context.Request.Method;
            var endpoint = context.Request.Path;

            _logger.LogInformation("Incoming request: Method = {HttpMethod}, Endpoint = {Endpoint}", httpMethod, endpoint);

            if(httpMethod != "GET") 
            {
                await LogRequestBody(context);
            }

            await _next(context);
        }

        private async Task LogRequestBody(HttpContext context)
        {
            context.Request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
            await context.Request.Body.ReadAsync(buffer);
            var requestBodyText = Encoding.UTF8.GetString(buffer);
            context.Request.Body.Position = 0;
            _logger.LogInformation("Request body: {RequestBody}", requestBodyText);
        }
    }
}
