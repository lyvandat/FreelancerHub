using DeToiServer.Dtos.ServiceStatusDtos;
using DeToiServer.Services.ServiceStatusService;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("/api/service-status")]
    public class ServiceStatusController : Controller
    {
        private readonly IServiceStatusService _statusService;

        public ServiceStatusController(IServiceStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetServiceStatusDto>>> GetAllServiceStatuses()
        {
            return Ok(await _statusService.GetAll());
        }
    }
}
