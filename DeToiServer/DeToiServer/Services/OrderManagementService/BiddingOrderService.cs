using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;

namespace DeToiServer.Services.OrderManagementService
{
    public class BiddingOrderService : IBiddingOrderService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public BiddingOrderService(IMapper mapper, UnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<GetOrderDto>> GetFreelancerBiddingOrders(Guid freelancerId)
        {
            var biddingOrderDetail = await _uow.BiddingOrderRepo.GetByFreelancerIdWithOrderDetail(freelancerId);

            if (biddingOrderDetail == null || !biddingOrderDetail.Any())
            {
                return Enumerable.Empty<GetOrderDto>();
            }

            return biddingOrderDetail.Select(bo => {
                var mapOrder = _mapper.Map<GetOrderDto>(bo.Order);
                mapOrder.PreviewPrice = bo.PreviewPrice;

                return mapOrder;
            });
        }

        public async Task<IEnumerable<GetFreelanceMatchingDto>> GetFreelancersForCustomerBiddingOrder(Guid orderId)
        {
            var biddingOrderDetail = await _uow.BiddingOrderRepo.GetMatchingFreelancersByOrderId(orderId);

            return biddingOrderDetail.Select(bo => 
            {
                var freelancer = _mapper.Map<GetFreelanceMatchingDto>(bo.Freelancer);

                if (freelancer == null)
                {
                    throw new InvalidCastException("Có lỗi trong quá trình lấy thông tin freelancers báo giá");
                }

                freelancer.PreviewPrice = bo.PreviewPrice;
                return freelancer;
            });
        }
    }
}