namespace AspNetCoreFundamentalsDemo
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MyMiddleware> _logger;
        private readonly IOperationSingleton _operationSingleton;

        public MyMiddleware(RequestDelegate next,
            ILogger<MyMiddleware> logger,
            IOperationSingleton operationSingleton)
        {
            _next = next;
            _logger = logger;
            _operationSingleton = operationSingleton;
        }

        public async Task InvokeAsync(HttpContext context, 
            IOperationTransient operationTransient,
            IOperationScoped operationScoped)
        {
            _logger.LogInformation($"Transient: {operationTransient.OperationId}");
            _logger.LogInformation($"Scoped: {operationScoped.OperationId}");
            _logger.LogInformation($"Singleton: {_operationSingleton.OperationId}");

            await _next(context);
        }

    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
