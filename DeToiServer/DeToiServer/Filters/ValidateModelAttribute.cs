using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace DeToiServer.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = new List<string>();

                foreach (var item in context.ModelState)
                {
                    if (item.Value.Errors.Any())
                    {
                        messages.AddRange(item.Value.Errors.Select(e => e.ErrorMessage));
                    }
                }

                context.Result = new BadRequestObjectResult(new
                {
                    Message = string.Join(", ", messages)
                });
            }
        }
    }
}
