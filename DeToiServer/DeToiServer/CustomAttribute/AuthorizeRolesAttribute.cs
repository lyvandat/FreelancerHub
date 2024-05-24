using DeToiServerCore.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DeToiServer.CustomAttribute;
using System.Management;
using System.Net;

namespace DeToiServerCore.CustomAttribute
{
    public class AuthorizeRolesFilter : IAuthorizationFilter
    {
        private readonly string? _roles;

        public AuthorizeRolesFilter(string? roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Claims.Any())
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    Message = GlobalConstant.UnauthorizeMessage,
                });
                return;
            }

            if (!string.IsNullOrEmpty(_roles))
            {
                var check = _roles.Contains(context.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? "default");

                if (!check)
                {
                    context.Result = new ObjectResult(new
                    {
                        Message = GlobalConstant.NeedAuthorizeMessage,
                    }) { StatusCode = (int)HttpStatusCode.Forbidden };
                    return;
                }
            }
        }
    }

    public class AuthorizeRolesAttribute : TypeFilterAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles)
            : base(typeof(AuthorizeRolesFilter))
        {
            Arguments = new object[] { string.Join("|", roles) };
        }
    }
}
