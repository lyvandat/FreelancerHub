using AutoMapper;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.ServiceDtos;
using DeToiServer.Dtos.UIElementDtos;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.UIElementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.SevicesUIElement;
using DeToiServerData.Repositories.UIElementServiceRequirementRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeToiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIElementController : ControllerBase
    {
        private readonly IUIElementServiceRequirementService _requirementService;
        private readonly INotificationService _notificationService;
        private readonly INotificationDataService _notificationDataService;
        private readonly IMapper _mapper;
        public UIElementController(
            IUIElementServiceRequirementService requirementService,
            INotificationService notiService,
            INotificationDataService notificationDataService,
            IMapper mapper)
        {
            _requirementService = requirementService;
            _notificationService = notiService;
            _notificationDataService = notificationDataService;
            _mapper = mapper;
        }

        [HttpGet("test")]
        public async Task<IEnumerable<UIElementServiceRequirementDto>> Test()
        {
            var raw = await _requirementService.GetAllWithDetail();

            return raw.Select(item => _mapper.Map<UIElementServiceRequirementDto>(item)).ToList();
        }

        [HttpPost("test2")]
        public async Task<PostUIElementValidationTypeDto> Test2(PostUIElementValidationTypeDto input)
        {
            await Task.Delay(10);

            return input;
        }

        [HttpGet("test3")]
        public async Task<IEnumerable<ServiceDto>> Test3()
        {
            var res = await _requirementService.GetServiceClone();

            return res;
        }

        [HttpPost("test4")]
        public async Task<ActionResult<ServiceDto>> Test4(Guid input)
        {
            var res = await _requirementService.GetAllWithIcon(input);

            if (res == null)
            {
                return BadRequest(new
                {
                    Message = "Lỗi"
                });
            }
            // await 

            return Ok(res);
        }
        [HttpPost("test5")]
        public async Task<ActionResult<string>> Test5(string input)
        {
            // var res = await _requirementService.AddServiceClone(input);

            var res = JsonConvert.DeserializeObject<IEnumerable<RequirementDataDto>>(input);
            if (res == null)
            {
                return BadRequest(new
                {
                    Message = "Lỗi"
                });
            }
            // await 
            await Task.Delay(10);

            return Ok(res);
        }

        [HttpPost("test6")]
        public async Task<ActionResult<string>> Test6()
        {
            // var res = await _requirementService.AddServiceClone(input);

            // Send success to choosen freelancer
            await _notificationService.PushNotificationAsync(new PushNotificationDto()
            {
                ExpoPushTokens = ["test"],
                Title = "📣 Bạn đã được chọn!",
                Body = "Customer đã chọn bạn! Hãy kiểm tra danh sách đơn nhé.",
                Data = new PushNotificationDataDto()
                {
                    ActionKey = GlobalConstant.Notification.CustomerChooseThisFreelancer,
                },
            }, [Guid.Parse("a7a76113-1a12-46c5-abec-01b0cccd1dde")]);

            var list = await _notificationDataService.GetAllNotificationByAcountId(Guid.Parse("a7a76113-1a12-46c5-abec-01b0cccd1dde"));

            foreach (var item in list)
            {
                
            }

            return Ok(list);
        }

    }
}
