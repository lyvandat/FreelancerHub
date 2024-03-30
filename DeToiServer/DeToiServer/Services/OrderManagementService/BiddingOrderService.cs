using AutoMapper;
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

            return biddingOrderDetail.Select(bo => _mapper.Map<GetOrderDto>(bo.Order));
        }
    }
}
