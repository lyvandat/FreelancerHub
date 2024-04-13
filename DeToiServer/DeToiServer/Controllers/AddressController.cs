using AutoMapper;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.OrderManagementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [Route("api/v1/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly IOrderManagementService _orderService;
        private readonly IFreelanceQuizService _quizService;
        private readonly IFreelanceSkillService _skillService;
        private readonly IBiddingOrderService _biddingOrderService;
        private readonly IMapper _mapper;

        public AddressController(
            IAccountService accService,
            IFreelanceAccountService freelanceAccountService,
            IOrderManagementService orderService,
            IFreelanceQuizService quizService,
            IFreelanceSkillService skillService,
            IBiddingOrderService biddingOrderService,
            IMapper mapper)
        {
            _accService = accService;
            _freelanceAccService = freelanceAccountService;
            _orderService = orderService;
            _quizService = quizService;
            _skillService = skillService;
            _biddingOrderService = biddingOrderService;
            _mapper = mapper;
        }
    }
}
