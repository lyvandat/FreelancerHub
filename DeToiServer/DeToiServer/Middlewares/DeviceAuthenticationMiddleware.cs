using DeToiServerCore.Common.Constants;
using System.Net;
using System;
using System.Security.Claims;

namespace DeToiServer.Middlewares
{
    public class DeviceAuthenticationMiddleware
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RequestDelegate _next;

        public DeviceAuthenticationMiddleware(
            IServiceProvider serviceProvider,
            RequestDelegate next)
        {
            _serviceProvider = serviceProvider;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!await ValidateSession(context))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                var errorDetails = new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = GlobalConstant.MultipleDevicesLoginDetected
                };

                await context.Response.WriteAsync(errorDetails.ToString());
            }
            else
            {
                await _next(context);
            }
        }

        public async Task<bool> ValidateSession(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                List<string> validRoles = [
                    GlobalConstant.Customer,
                    GlobalConstant.Freelancer,
                    GlobalConstant.UnverifiedFreelancer
                ];

                var role = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                if (role != null && validRoles.Contains(role))
                {
                    if (Guid.TryParse(context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.WindowsDeviceClaim)?.Value, out var sessionId)
                        && Guid.TryParse(context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out var accountId))
                    {
                        using var scope = _serviceProvider.CreateScope();
                        UnitOfWork _unitOfWork = scope.ServiceProvider.GetRequiredService<UnitOfWork>();

                        return await _unitOfWork.AccountRepo.ValidateAccountSessionAsync(accountId, sessionId);
                    }
                }
            }

            return true;
        }
    }
}
