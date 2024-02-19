using AutoMapper;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Order> Add(PostOrderDto postOrderDto)
        {
            var order = _mapper.Map<Order>(postOrderDto);
            await _uow.OrderRepo.CreateAsync(order);
            return order;
        }
    }
}
