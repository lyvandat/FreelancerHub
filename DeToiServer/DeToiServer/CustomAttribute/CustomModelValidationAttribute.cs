using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using DeToiServerCore.Common.Constants;

namespace DeToiServer.CustomAttribute
{
    public class ValidationErrorDto
    {
        public string Field { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }

    public class ValidationResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public List<ValidationErrorDto> Errors { get; set; } = [];
    }
}
