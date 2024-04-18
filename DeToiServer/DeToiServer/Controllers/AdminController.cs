using AutoMapper;
using DeToiServer.Dtos.AdminDto;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAccountService _accService;
        private readonly IOrderManagementService _orderService;

        public AdminController(
            UnitOfWork uow,
            IMapper mapper,
            IAccountService accService,
            IOrderManagementService orderService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _accService = accService;
            _orderService = orderService;
        }

        // Doanh thu = 5% Tiền dịch vụ
        // Tổng tiền = Tiền dịch vụ + Doanh thu

        

        [HttpGet("overview"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<GetOverviewDataAdminDto>> GetOverviewDataAdmin()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var result = await _accService.GetAccountDetailsById(accountId);

            if (result is null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy tài khoản!"
                });
            }

            return Ok(new
            {
                message = "Test"
            });
        }

        [HttpGet("overview1"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<ManageCustomerAccountDto>> GetOverviewDataAdmin1()
        {
            return Ok(new
            {
                message = "Test"
            });
        }

        [HttpGet("overview2"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<ManageFreelancerAccountDto>> GetOverviewDataAdmin2()
        {
            return Ok(new
            {
                message = "Test"
            });
        }

        [HttpGet("overview3"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<FreelancerAccountLicensingDto>> GetOverviewDataAdmin3()
        {
            return Ok(new
            {
                message = "Test"
            });
        }

        [HttpGet("overview4"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<ManageListServiceCategoryDto>> GetOverviewDataAdmin4()
        {
            return Ok(new
            {
                message = "Test"
            });
        }

        [HttpGet("overview5"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<ManageServiceCategoryDto>> GetOverviewDataAdmin5()
        {
            return Ok(new
            {
                message = "Test"
            });
        }

        [HttpGet("order"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetOrders([FromQuery] FilterOrderQuery filterOrderQuery)
        {

            var order = await _orderService.GetAllOrder(filterOrderQuery);

            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Lấy đơn đặt hàng không thành công"
                });
            }

            var orderPage = PageList<GetOrderDto>.ToPageList(order.AsQueryable(), filterOrderQuery.Page, filterOrderQuery.PageSize);
            return Ok(orderPage);
        }

        [HttpGet("order/detail"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<GetOrderDto>> GetOrderById(Guid id)
        {

            var order = await _orderService.GetOrderDetailById(id);

            if (order is null)
            {
                return BadRequest(new
                {
                    Message = "Lấy đơn đặt hàng không thành công"
                });
            }

            return Ok(order);
        }
    }
}
