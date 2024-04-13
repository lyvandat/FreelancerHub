using AutoMapper;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.OrderManagementService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeToiServer.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly ICustomerAccountService _customerService;
        private readonly IMapper _mapper;

        public CustomerAccountController(
            IAccountService accService,
            ICustomerAccountService customerAccountService,
            IMapper mapper)
        {
            _accService = accService;
            _customerService = customerAccountService;
            _mapper = mapper;
        }


    }
}
