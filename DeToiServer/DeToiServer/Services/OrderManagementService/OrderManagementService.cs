using AutoMapper;
using DeToiServer.Dtos;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServerCore.Models.Accounts;
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

        public T? AddService<T>(PostServiceDto? postService, Guid orderId, Guid serviceTypeId) 
            where T : Service
        {
            if (postService == null) return null;
            var service = _mapper.Map<T>(postService);
            service.ServiceTypeId = serviceTypeId;

            var orderServiceList = new List<OrderService>
            {
                new OrderService() { OrderId = orderId, ServiceId = service.Id, Service = service }
            };

            service.OrderServices = orderServiceList;
            return service;
        }

        public async Task<Order?> AddClone(PostTestOrderDto postOrderDto)
        {
            var rawOrder = _mapper.Map<Order>(postOrderDto);
            var searchAddress = await _uow.AddressRepo.GetByIdAsync(postOrderDto.Address.Id);
            if (searchAddress == null)
            {
                rawOrder.Address = _mapper.Map<Address>(rawOrder.Address);
                rawOrder.Address.CustomerAccountId = postOrderDto.CustomerId;
            }
            else
                rawOrder.AddressId = postOrderDto.Address.Id ?? Guid.Empty;

            //rawOrder.
            await _uow.OrderRepo.CreateAsync(rawOrder);
            rawOrder.OrderServiceTypes ??= new List<OrderServiceType>()
            {
                new() { ServiceTypeId = postOrderDto.ServiceId }
            };

            // Add services related to the order
            // await _uow.ServiceTypeRepo.AddOrderServiceType(postOrderDto.ServiceId, rawOrder.Id);
            var cleaningService = AddService<CleaningService>(postOrderDto.CleaningService, rawOrder.Id, postOrderDto.ServiceId);

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

        public async Task<Order?> Add(PostOrderDto postOrderDto)
        {
            var rawOrder = _mapper.Map<Order>(postOrderDto);

            await _uow.OrderRepo.CreateAsync(rawOrder);

            // Add services related to the order
            var cleaningService = AddService<CleaningService>(postOrderDto.CleaningService, rawOrder.Id, postOrderDto.ServiceId);
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

        public async Task<IEnumerable<Order>?> GetFreelancerMatchingOrders(Guid freelancerId)
        {
            await Task.Delay(10);

            return null;
        }
    }
}
