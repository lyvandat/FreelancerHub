using AutoMapper;
using DeToiServer.Dtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Services.OrderManagementService
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderManagementService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public T? AddService<T>(PostServiceDto? postService, Guid orderId) 
            where T : Service
        {
            if (postService == null) return null;
            var service = _mapper.Map<T>(postService);
            var orderServiceList = new List<OrderService>
            {
                new OrderService() { OrderId = orderId, ServiceId = Guid.Empty }
            };

            service.OrderServices = orderServiceList;
            return service;
        }

        public async Task<Order?> Add(PostOrderDto postOrderDto)
        {
            var rawOrder = _mapper.Map<Order>(postOrderDto);
            await _uow.OrderRepo.CreateAsync(rawOrder);

            // Add services related to the order
            var cleaningService = AddService<CleaningService>(postOrderDto.CleaningService, rawOrder.Id);
            //var repairingService = AddService<RepairingService>(postOrderDto.RepairingService, rawOrder.Id);
            //var shoppingService = AddService<ShoppingService>(postOrderDto.ShoppingService, rawOrder.Id);

            // Create records for each service
            await _uow.CleaningRepo.CreateAsync(cleaningService);
            //await _uow.RepairingRepo.CreateAsync(repairingService);
            //await _uow.ShoppingRepo.CreateAsync(shoppingService);

            // Save changes within the transaction scope
            if (!await _uow.SaveChangesAsync()) return null;

            return rawOrder;
        }
    }
}
