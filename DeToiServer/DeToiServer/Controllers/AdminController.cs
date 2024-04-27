using AutoMapper;
using DeToiServer.Dtos.AdminDto;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.AdminService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.OrderManagementService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IAdminService _adminService;
        private readonly INotificationService _notificationService;


        public AdminController(
            UnitOfWork uow,
            IMapper mapper,
            IAccountService accService,
            IOrderManagementService orderService,
            IAdminService adminService,
            INotificationService notificationService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _accService = accService;
            _orderService = orderService;
            _adminService = adminService;
            _notificationService = notificationService;
        }

        // Doanh thu = 5% Tiền dịch vụ
        // Tổng tiền = Tiền dịch vụ + Doanh thu

        

        [HttpPost("overview")] // , AuthorizeRoles(GlobalConstant.Admin)
        public async Task<ActionResult<GetOverviewDataAdminDto>> GetOverviewDataAdmin(
            ServiceOverviewQueryDto query
        )
        {
            //_ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            //var result = await _accService.GetAccountDetailsById(accountId);

            //if (result is null)
            //{
            //    return NotFound(new
            //    {
            //        message = "Không tìm thấy tài khoản!"
            //    });
            //}

            return Ok(await _adminService.GetAllOverviewDataAdmin(query));
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


        private async Task<ActionResult<GetOrderDto>> PostNotiTest(PushNotificationDto postData)
        {

            var order = await _notificationService.PushSendAsync(_mapper.Map<PushTicketRequest>(postData));

            return Ok(order);
        }
    }
}
