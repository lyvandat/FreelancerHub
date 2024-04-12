using AutoMapper;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DeToiServer.Controllers
{
    [Route("api/v1/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAccountService _accService;

        public AdminController(
            UnitOfWork uow, 
            IMapper mapper, 
            IAccountService accService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _accService = accService;
        }

        // Doanh thu = 5% Tiền dịch vụ
        // Tổng tiền = Tiền dịch vụ + Doanh thu

    }
}
