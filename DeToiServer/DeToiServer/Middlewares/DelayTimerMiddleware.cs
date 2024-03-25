using DeToiServerCore.Common.Helper;
using Microsoft.Extensions.Options;

namespace DeToiServer.Middlewares
{
    public class DelayTimerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly int _delay;
        private readonly List<string> _ignoreSegments = [
            "/chat-hub"
        ];

        public DelayTimerMiddleware(RequestDelegate next, IOptions<ApplicationSecretSettings> appSecret)
        {
            _next = next;
            if (!int.TryParse(appSecret.Value?.DelayTime, out _delay))
                _delay = Helper.GetDockerDelayPeriod();
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (!_ignoreSegments.Any(segment => context.Request.Path.StartsWithSegments(segment)))
            {
                await Task.Delay(_delay);
            }
        }
    }
}
