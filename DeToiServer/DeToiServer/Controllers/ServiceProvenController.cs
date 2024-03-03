using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServer.Services.ServiceProvenService;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/service-proven")]
    public class ServicerProvenController : Controller
    {
        private readonly IServiceProvenService _serviceProven;
        private readonly UnitOfWork _uow;

        public ServicerProvenController(IServiceProvenService service, UnitOfWork uow)
        {
            _serviceProven = service;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceProven>>> GetServiceProven()
        {
            return Ok(await _serviceProven.GetAll());
        }

        [HttpGet("detail")]
        public async Task<ActionResult<ServiceProven>> GetServiceProvenDetail(Guid id)
        {
            return Ok(await _serviceProven.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceProven>> PostServiceProven(PostServiceProvenDto postServiceProven)
        {
            var serviceProven = await _serviceProven.Add(postServiceProven);
            await _uow.SaveChangesAsync();
            return CreatedAtAction(nameof(GetServiceProvenDetail), new { id = serviceProven.Id }, serviceProven);
        }
    }
}
