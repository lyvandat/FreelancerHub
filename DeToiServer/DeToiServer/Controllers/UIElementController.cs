using AutoMapper;
using DeToiServer.Dtos.UIElementDtos;
using DeToiServer.Services.UIElementService;
using DeToiServerCore.Models.SevicesUIElement;
using DeToiServerData.Repositories.UIElementServiceRequirementRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace DeToiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIElementController : ControllerBase
    {
        private readonly IUIElementServiceRequirementService _requirementService;
        private readonly IMapper _mapper;
        public UIElementController(IUIElementServiceRequirementService requirementService, IMapper mapper)
        {
            _requirementService = requirementService;
            _mapper = mapper;
        }

        [HttpGet("test")]
        public async Task<IEnumerable<UIElementServiceRequirementDto>> Test()
        {
            var raw = await _requirementService.GetAllWithDetail();

            return raw.Select(item => _mapper.Map<UIElementServiceRequirementDto>(item)).ToList();
        }
    }
}
