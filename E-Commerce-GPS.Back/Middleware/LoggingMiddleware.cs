namespace EcommerceBackend.Middleware
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

		public async Task InvokeAsync(HttpContext context)
		{
			_logger.LogInformation("Recebendo requisição: {method} {path}", context.Request.Method, context.Request.Path);

			await _next(context);

			_logger.LogInformation("Finalizando requisição: {method} {path} com status {statusCode}", context.Request.Method, context.Request.Path, context.Response.StatusCode);
		}
	}
}