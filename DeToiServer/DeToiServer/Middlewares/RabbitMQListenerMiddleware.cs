using DeToiServer.RealTime;

namespace DeToiServer.Middlewares
{
    public class RabbitMQListenerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RabbitMQConsumer _listener;

        public RabbitMQListenerMiddleware(RequestDelegate next, RabbitMQConsumer listener)
        {
            _next = next;
            _listener = listener;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (!context.Request.Path.StartsWithSegments("/chat-hub"))
            {
                // If it's a SignalR request, do not execute further middleware
                _listener.ReceiveMessageFromQ();
                _listener.ReceiveOrderStatusFromQ();
            }
        }
    }
}
