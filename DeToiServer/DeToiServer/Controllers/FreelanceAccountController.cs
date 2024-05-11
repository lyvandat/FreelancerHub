using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.PaymentDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.SkillDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.QueryModels.OrderQueryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DeToiServer.Controllers
{
    [Route("api/v1/freelancer")]
    [ApiController]
    public class FreelanceAccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly ICustomerAccountService _customerAccountService;
        private readonly IOrderManagementService _orderService;
        private readonly IFreelanceQuizService _quizService;
        private readonly IFreelanceSkillService _skillService;
        private readonly IBiddingOrderService _biddingOrderService;
        private readonly IPaymentService _paymentService;
        private readonly DataContext _context;
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public FreelanceAccountController(
            IAccountService accService,
            IFreelanceAccountService freelanceAccountService,
            ICustomerAccountService customerAccountService,
            IOrderManagementService orderService,
            IFreelanceQuizService quizService,
            IFreelanceSkillService skillService,
            IBiddingOrderService biddingOrderService,
            IPaymentService paymentService,
            DataContext context,
            UnitOfWork unitOfWork,
            IMapper mapper)
        {
            _accService = accService;
            _freelanceAccService = freelanceAccountService;
            _customerAccountService = customerAccountService;
            _orderService = orderService;
            _quizService = quizService;
            _skillService = skillService;
            _biddingOrderService = biddingOrderService;
            _paymentService = paymentService;
            _context = context;
            _uow = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<GetFreelanceDto>> GetAllFreelancer()
        {
            var freelance = await _freelanceAccService.GetAllFreelanceDetail();
            return Ok(_mapper.Map<IEnumerable<GetFreelanceDto>>(freelance));
        }

        [HttpGet("detail")] // , AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)
        public async Task<ActionResult<GetFreelanceDto>> GetFreelancerDetail(Guid id)
        {
            var freelance = await _freelanceAccService.GetDetailWithStatistic(id);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            return Ok(_mapper.Map<GetFreelanceDto>(freelance));
        }

        [HttpGet("wallet"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetFreelancerWalletDto>> GetCurrentFreelancerWallet()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelanceWallet = await _freelanceAccService.GetByAccIdWithWallet(accountId);


            if (freelanceWallet is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            return Ok(freelanceWallet);
        }

        [HttpGet("short-detail"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetFreelanceAccountShortDetailDto>> GetFreelancerShortDetail()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerAccountId);
            var freelancer = await _freelanceAccService.GetByAccId(freelancerAccountId);
            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }

            return Ok(_mapper.Map<GetFreelanceAccountShortDetailDto>(freelancer));
        }

        [HttpGet("current"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetFreelanceDto>> GetCurrentFreelancerDetail()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }
            var result = await _freelanceAccService.GetDetailWithStatistic(freelancerId);

            return Ok(_mapper.Map<GetFreelanceDto>(result));
        }

        /// <summary>
        /// get a list of orders which are waiting to be picked
        /// TODO: Optimize this if necessary
        /// TODO: Orders that the freelancer has finished ?
        /// </summary>
        [HttpGet("orders"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetCurrentFreelancerMatchingOrders([FromQuery] FilterFreelancerOrderQuery filterQuery)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _orderService.GetFreelancerSuitableOrders(freelance.Id, filterQuery);
            var orderPage = PageList<GetOrderDto>.ToPageList(result.AsQueryable(), filterQuery.Page, filterQuery.PageSize);

            return Ok(result);
        }

        /// <summary>
        /// Get incoming orders for the current freelancer
        /// </summary>
        [HttpGet("orders/incoming"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetFreelancerIncomingOrders(
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate
        )
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid freelancerId);
            var freelance = await _freelanceAccService.GetByAccId(freelancerId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _orderService.GetFreelancerIncomingOrders(new FilterFreelancerIncomingOrderQuery()
            {
                FreelancerId = freelance.Id,
                FromDate = fromDate?.Date,
                ToDate = toDate?.Date,
            });

            return Ok(result);
        }

        /// <summary>
        /// Get Completed orders for the current freelancer
        /// </summary>
        [HttpGet("orders/completed"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetFreelancerCompletedOrders(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null
        )
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _orderService.GetFreelancerCompletedOrders(new FilterFreelancerIncomingOrderQuery()
            {
                FreelancerId = freelance.Id,
                FromDate = fromDate?.Date,
                ToDate = toDate?.Date,
            });

            return Ok(result);
        }

        [HttpGet("added-skills-and-done-test"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<IsFreelancerAddedSkillAndDoneTest>> IsFreelancerHaveSkillsAndDoneTest()
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Có lỗi xảy ra trong quá trình đăng nhập, xin hãy thử lại"
                });
            }

            var result = _mapper.Map<GetFreelanceDto>(freelance);

            return Ok(new IsFreelancerAddedSkillAndDoneTest()
            {
                IsAddedServiceType = !(result.FreelancerFeasibleServices == null || result.FreelancerFeasibleServices.Count == 0),
                IsAddedSkill = !(result.Skills == null || result.Skills.Count == 0),
                IsDoneTest = await _quizService.IsFreelancerDoneQuiz(freelance.Id),
            });
        }


        /// <summary>
        /// get a list of freelancers who have auctioned an order
        /// </summary>
        [HttpGet("customer-bidding"), AuthorizeRoles(GlobalConstant.Customer)]
        public async Task<ActionResult<IEnumerable<GetFreelanceMatchingDto>>> GetBiddingOrders(Guid orderId)
        {
            Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var customerAcc = await _accService.GetById(accountId);

            if (customerAcc == null)
            {
                return BadRequest(new
                {
                    Message = "Vui lòng đăng nhập để tiếp tục"
                });
            }

            return Ok(await _biddingOrderService.GetFreelancersForCustomerBiddingOrder(orderId, Guid.Empty));
        }


        [HttpPost("add-multiple-service-type"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<IEnumerable<GetServiceTypeDto>>> AddMultipleFreelancerServiceTypes(ChooseFreelancerServiceTypesDto postSkills)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Có lỗi xảy ra trong quá trình đăng nhập, xin hãy thử lại"
                });
            }

            var result = await _freelanceAccService.AddServiceTypesFreelancer(freelance.Id, postSkills.ServiceTypes);

            if (result.Any())
            {
                await _uow.SaveChangesAsync();
            }
            //return BadRequest(new
            //{
            //    Message = "Các dịch vụ này đã được thêm vào tài khoản, xin hãy thử lại"
            //});

            return Ok(new
            {
                Message = "Thêm dịch vụ cho Freelancer thành công"
            });
        }

        /// <summary>
        /// Need to delete.
        /// </summary>
        [HttpPost("bid-test"), AuthorizeRoles(GlobalConstant.Freelancer)]
        public async Task<ActionResult<string>> TestBid(GetFreelancerAndPreviewPriceDto bid)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var freelancer = await _freelanceAccService.GetDetailWithStatistic(accountId);

            if (freelancer == null)
            {
                return BadRequest(new
                {
                    Message = "Sai Id freelancer"
                });
            }    

            if (bid.PreviewPrice < (await _uow.PaymentRepo.GetAllFeeAsync())
                .Where(f => f.Id.Equals(GlobalConstant.Fee.Id.MinServicePrice)).First().Amount)
            {
                return BadRequest(new
                {
                    Message = "Baos gia sai"
                });
            }

            var order = await _orderService.GetById(bid.OrderId);

            if (order == null) return BadRequest(new
            {
                Message = "sai OrderId"
            });

            if (freelancer.Balance < order.EstimatedPrice || freelancer.Balance < bid.PreviewPrice)
            {
                return BadRequest(new
                {
                    Message = "khong du tienf"
                });
            }

            var customer = await _customerAccountService.GetByIdWithAccount(order.CustomerId);
            var biddingOrder = _mapper.Map<BiddingOrder>(new GetFreelancerAndPreviewPriceDto()
            {
                BiddingNote = bid.BiddingNote,
                PreviewPrice = bid.PreviewPrice,
                OrderId = bid.OrderId,
                FreelancerId = freelancer.Id,
            });
            var existingBiddingOrder = await _context.BiddingOrders
                .Where(bo => bo.OrderId == biddingOrder.OrderId && bo.FreelancerId == biddingOrder.FreelancerId)
                .FirstOrDefaultAsync();

            if (existingBiddingOrder != null)
            {
                // Add Notification here for fe to catch
                return BadRequest(new
                {
                    Message = "bid don nay roi"
                });
            }

            // Save bidding orders, update orderStatus.
            try
            {
                if (order.ServiceStatusId.Equals(StatusConst.Created))
                {
                    order.ServiceStatusId = StatusConst.OnMatching;
                }
                _context.BiddingOrders.Add(biddingOrder);


                if (!await _uow.SaveChangesAsync())
                {
                    // Add Notification here for fe to catch
                    return BadRequest(new
                    {
                        Message = "loi bao gia"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot save bidding order: " + ex.Message);
            }

            return Ok(new
            {
                Message = "Bid ok"
            });
        }
    }
}
