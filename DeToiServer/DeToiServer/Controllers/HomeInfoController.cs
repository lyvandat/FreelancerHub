using DeToiServer.Services.ServiceInfoService;
using DeToiServerCore.Models.Infos;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/home-info")]
    public class HomeInfoController : Controller
    {
        private readonly IHomeInfoService _service;
        private readonly UnitOfWork _uow;

        public HomeInfoController(IHomeInfoService service, UnitOfWork uow)
        {
            _service = service;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeInfo>>> GetHomeInfos()
        {
            return Ok(await _service.GetAll());
        }
    }
}
