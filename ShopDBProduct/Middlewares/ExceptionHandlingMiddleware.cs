using Microsoft.Extensions.Logging;

namespace ShopDBProduct.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        // đại diện cho cái tiếp theo (có thể là đi đến middleware khác, hay controller, ...) trong pipline
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    ArgumentException => StatusCodes.Status404NotFound,
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                var response = new
                {
                    statusCode = context.Response.StatusCode,
                    message = ex.Message,
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
