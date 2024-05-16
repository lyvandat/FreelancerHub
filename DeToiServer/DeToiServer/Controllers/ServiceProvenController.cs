using DeToiServer.Dtos.ServiceProvenDtos;
using DeToiServer.Services.ServiceProvenService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult<IEnumerable<GetServiceProvenDto>>> GetServiceProven()
        {
            return Ok(await _serviceProven.GetAll());
        }

        [HttpGet("detail")]
        public async Task<ActionResult<GetServiceProvenDto>> GetServiceProvenDetail(Guid id)
        {
            return Ok(await _serviceProven.GetById(id));
        }

        [HttpPost("before")]
        public async Task<ActionResult<GetServiceProvenDto>> PostServiceProvenBefore(PostServiceProvenDto postServiceProven)
        {
            var serviceProven = await _serviceProven.Add(postServiceProven, true);
            await _uow.SaveChangesAsync();
            return CreatedAtAction(nameof(GetServiceProvenDetail), new { id = serviceProven.Id }, serviceProven);
        }

        [HttpPost("after")]
        public async Task<ActionResult<GetServiceProvenDto>> PostServiceProvenAfter(PostServiceProvenDto postServiceProven)
        {
            var serviceProven = await _serviceProven.GetByOrderId(postServiceProven.OrderId);

            if (serviceProven != null)
            {
                var images = JsonConvert.DeserializeObject<ICollection<string>>(serviceProven.ImageAfter);
                if (images != null)
                {
                    serviceProven.ImageAfter = JsonConvert.SerializeObject(images.Concat(postServiceProven.MediaPath));
                }
                else
                {
                    serviceProven.ImageAfter = JsonConvert.SerializeObject(postServiceProven.MediaPath);
                }  
            }
            else
            {
                serviceProven = await _serviceProven.Add(postServiceProven);
            }

            await _uow.SaveChangesAsync();
            return CreatedAtAction(nameof(GetServiceProvenDetail), new { id = serviceProven.Id }, serviceProven);
        }
    }
}