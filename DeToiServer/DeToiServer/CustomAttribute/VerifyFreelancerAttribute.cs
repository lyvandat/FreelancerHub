using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using DeToiServerCore.Models.Accounts;

namespace DeToiServer.CustomAttribute
{
    public class VerifyFreelancerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is not ControllerBase controller)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Message = "Invalid controller"
                });
                return;
            }

            var countryCode = context.HttpContext.Request.Query["paramName"];

            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                var bodyContent = reader.ReadToEnd();
                // Parse or use bodyContent as needed

                
            }

            base.OnActionExecuting(context);
        }
    }
}
