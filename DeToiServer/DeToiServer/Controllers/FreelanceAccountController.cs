using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.CacheService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.FreelanceQuizService;
using DeToiServer.Services.FreelanceSkillService;
using DeToiServer.Services.NotificationService;
using DeToiServer.Services.OrderManagementService;
using DeToiServer.Services.PaymentService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.CustomAttribute;
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
        private readonly INotificationService _notificationService;
        private readonly IPaymentService _paymentService;
        private readonly ICacheService _cacheService;
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
            INotificationService notificationService,
            IPaymentService paymentService,
            ICacheService cacheService,
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
            _notificationService = notificationService;
            _paymentService = paymentService;
            _cacheService = cacheService;
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

        [HttpGet("detail")] // , Authorize]Roles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)
        public async Task<ActionResult<GetFreelanceDto>> GetFreelancerDetail(Guid id)
        {
            var cacheData = _cacheService.GetData<GetFreelanceDto>($"Freelancer{id}");

            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            var freelance = await _freelanceAccService.GetDetailWithStatistic(id);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            var result = _mapper.Map<GetFreelanceDto>(freelance);

            if (result != null)
            {
                _cacheService.SetData($"Freelancer{id}", result, DateTimeOffset.Now.AddSeconds(20));
            }

            return Ok(result);
        }

        [HttpGet("wallet"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetFreelancerWalletDto>> GetCurrentFreelancerWallet()
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            var cacheData = _cacheService.GetData<GetFreelancerWalletDto>($"Freelancer{accountId}-wallet");

            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            var freelanceWallet = await _freelanceAccService.GetByAccIdWithWallet(accountId);


            if (freelanceWallet is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            // TODO: Remove this cache data when we actually update freelancers' accounts
            _cacheService.SetData($"Freelancer{accountId}-wallet", freelanceWallet, DateTimeOffset.Now.AddSeconds(15));
            return Ok(freelanceWallet);
        }

        [HttpGet("short-detail"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetFreelanceAccountShortDetailDto>> GetFreelancerShortDetail()
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản Freelancer"
                });
            }

            var cacheData = _cacheService.GetData<GetFreelanceAccountShortDetailDto>($"Freelancer{accountId}-short");

            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            var freelancer = await _freelanceAccService.GetByAccId(accountId);
            if (freelancer is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản!"
                });
            }

            var result = _mapper.Map<GetFreelanceAccountShortDetailDto>(freelancer);

            if (result != null)
            {
                _cacheService.SetData($"Freelancer{accountId}-short", result, DateTimeOffset.Now.AddSeconds(30));
            }

            return Ok(result);
        }

        [HttpGet("current"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<GetFreelanceDto>> GetCurrentFreelancerDetail()
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var cacheData = _cacheService.GetData<GetFreelanceDto>($"Freelancer{accountId}-current");

            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }
            var result = await _freelanceAccService.GetDetailWithStatistic(accountId);
            var finalResult = _mapper.Map<GetFreelanceDto>(result);

            if (finalResult != null)
            {
                _cacheService.SetData($"Freelancer{accountId}-current", finalResult, DateTimeOffset.Now.AddSeconds(30));
            }

            return Ok(finalResult);
        }

        /// <summary>
        /// get a list of orders which are waiting to be picked
        /// TODO: Optimize this if necessary
        /// </summary>
        [HttpGet("orders"), AuthorizeRoles(GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> GetCurrentFreelancerSuitableOrders([FromQuery] FilterFreelancerOrderQuery filterQuery)
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var cacheData = _cacheService.GetData<IEnumerable<GetOrderDto>>($"Freelancer{accountId}-suitable-order");

            if (cacheData != null && cacheData.Any())
            {
                return Ok(cacheData);
            }

            var freelance = await _freelanceAccService.GetByAccId(accountId);

            if (freelance is null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var result = await _orderService.GetFreelancerSuitableOrders(freelance.Id, filterQuery);
            var orderPage = PageList<GetOrderDto>.ToPageList(result.AsQueryable(), filterQuery.Page, filterQuery.PageSize);

            if (result != null && result.Any())
            {
                _cacheService.SetData($"Freelancer{accountId}-suitable-order", result, DateTimeOffset.Now.AddSeconds(20));
            }

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
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var cacheData = _cacheService.GetData<IEnumerable<GetOrderDto>>($"Freelancer{accountId}-incoming-order-{fromDate}-{toDate}");

            if (cacheData != null && cacheData.Any())
            {
                return Ok(cacheData);
            }

            var freelance = await _freelanceAccService.GetByAccId(accountId);

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

            if (result != null && result.Any())
            {
                _cacheService.SetData($"Freelancer{accountId}-incoming-order-{fromDate}-{toDate}", result, DateTimeOffset.Now.AddSeconds(20));
            }

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
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản, hãy đăng nhập để thử lại"
                });
            }

            var cacheData = _cacheService.GetData<IEnumerable<GetOrderDto>>($"Freelancer{accountId}-completed-order-{fromDate}-{toDate}");

            if (cacheData != null && cacheData.Any())
            {
                return Ok(cacheData);
            }

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

            if (result != null && result.Any())
            {
                _cacheService.SetData($"Freelancer{accountId}-completed-order-{fromDate}-{toDate}", result, DateTimeOffset.Now.AddSeconds(20));
            }

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
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId))
            {
                return BadRequest(new
                {
                    Message = "Vui lòng đăng nhập để tiếp tục"
                });
            }

            var cacheData = _cacheService.GetData<IEnumerable<GetFreelanceMatchingDto>>($"Customer{accountId}-order{orderId}-freelancers");

            if (cacheData != null && cacheData.Any())
            {
                return Ok(cacheData);
            }

            var customerAcc = await _accService.GetById(accountId);

            if (customerAcc == null)
            {
                return BadRequest(new
                {
                    Message = "Vui lòng đăng nhập để tiếp tục"
                });
            }

            var result = await _biddingOrderService.GetFreelancersForCustomerBiddingOrder(orderId, Guid.Empty);

            if (result != null)
            {
                _cacheService.SetData($"Customer{accountId}-order{orderId}-freelancers", result, DateTimeOffset.Now.AddSeconds(20));
            }

            return Ok(result);
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

            var order = await _orderService.GetByIdWithServiceType(bid.OrderId);

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

                await _notificationService.PushNotificationAsync(new PushNotificationDto()
                {
                    ExpoPushTokens = [customer.Account.ExpoPushToken],
                    Title = $"📣 Đã có Freelancer báo giá!",
                    Body = $"Đơn dịch vụ {order.OrderServiceTypes.First().ServiceType.Name} của bạn được Freelancer đã báo giá!",
                    Data = new()
                    {
                        ActionKey = GlobalConstant.Notification.FreelancerQuoteServiceToCustomer,
                    },
                }, [customer.AccountId]);
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
