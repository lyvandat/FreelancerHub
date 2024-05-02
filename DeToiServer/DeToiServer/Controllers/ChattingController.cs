using AutoMapper;
using DeToiServer.Dtos.ChattingDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.ChattingService;
using DeToiServer.Services.NotificationService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/account/chat")]
    [ApiController]
    public class ChattingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IChattingService _chattingService;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public ChattingController(
            IAccountService accService,
            IChattingService chattingService,
            IMapper mapper,
            UnitOfWork uow)
        {
            _accountService = accService;
            _chattingService = chattingService;
            _mapper = mapper;
            _uow = uow;
        }

        // TODO: add APIs constraints, ...

        [HttpGet("detail"), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetAccountChatSession(
            [FromQuery] Guid receiverId,
            [FromQuery] int Page = 1,
            [FromQuery] int PageSize = 30
        )
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            


            var result = await _chattingService.GetCurrentChatSession(accountId, receiverId, Page, PageSize);
            return Ok(result);
        }

        [HttpPost(""), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<MessageDto>>> PostChatToAccount(PostSendMessageDto sendMessage)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);



            var sentMessage = await _chattingService.PostSendMessageByAccountId(accountId, sendMessage);
            await _uow.SaveChangesAsync();


            return Ok(sentMessage);
        }

        [HttpGet("history"), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer)]
        public async Task<ActionResult<IEnumerable<GetMessagePreviewDto>>> GetAccountChatHistory()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);



            var messages = await _chattingService.GetMessageHistoryByAccountId(accountId);


            return Ok(messages);
        }
    }
}
