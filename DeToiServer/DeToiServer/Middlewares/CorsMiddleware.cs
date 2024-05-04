namespace DeToiServer.Middlewares
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue("Origin", out var originValue))
            {
                httpContext.Response.Headers.Append("Access-Control-Allow-Credentials", "true");
                httpContext.Response.Headers.Append("Access-Control-Allow-Headers", "x-requested-with");
                httpContext.Response.Headers.Append("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                httpContext.Response.Headers.Append("Access-Control-Allow-Origin", originValue);

                if (httpContext.Request.Method == "OPTIONS")
                {
                    httpContext.Response.StatusCode = 204;
                    return httpContext.Response.WriteAsync(string.Empty);
                }
            }

            return _next(httpContext);
        }
    }
}
