using AutoMapper;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.OrderQueryModels;

namespace DeToiServer.Services.OrderManagementService
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private const int MAX_SERVICE = 50;

        public OrderManagementService(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Service? AddService(ServiceDto? postService, Guid orderId, Order order)
        {
            if (postService == null) return null;
            var service = _mapper.Map<Service>(postService);

            // Add service relationship
            var orderServiceList = new List<OrderService>(1)
            {
                new OrderService() { OrderId = orderId }
            };

            // Add service type relationship
            var newOrderServiceType = new OrderServiceType() { OrderId = orderId, ServiceTypeId = service.ServiceTypeId };
            if (order.OrderServiceTypes == null)
            {
                order.OrderServiceTypes = new List<OrderServiceType>(MAX_SERVICE)
                {
                    newOrderServiceType
                };
            }
            else
            {
                order.OrderServiceTypes.Add(newOrderServiceType);
            }

            service.OrderServices = orderServiceList;
            return service;
        }

        private async Task<ServiceDto?> MapServiceRequirementsWithIcon(PostServiceDto? serviceToMap)
        {
            if (serviceToMap == null) return null;
            await Task.Delay(10);
            var reqElement = await _uow.UIElementServiceRequirementRepo.GetAllWithIcon(serviceToMap.ServiceTypeId);
            var areqElement = await _uow.UIElementAdditionServiceRequirementRepo.GetAllWithIcon(serviceToMap.ServiceTypeId);

            foreach (var item in serviceToMap.Requirement)
            {
                var req = reqElement.FirstOrDefault(e => e.Key.Equals(item.Key));
                if (req != null)
                {
                    item.Icon = req.LabelIcon;
                    item.Label = req.Label;
                }
                else
                {
                    item.Icon = GlobalConstant.Requirement.DefaultRequirementIcon;
                    item.Label = "Yêu cầu";
                }
            }

            foreach (var item in serviceToMap.AdditionalRequirement)
            {
                var req = areqElement.FirstOrDefault(e => e.Key.Equals(item.Key));
                if (req != null)
                {
                    item.Icon = req.Icon;
                    item.Label = req.Label;
                }
                else
                {
                    item.Icon = GlobalConstant.Requirement.DefaultRequirementIcon;
                    item.Label = "Yêu cầu";
                }
            }

            return _mapper.Map<ServiceDto>(serviceToMap);
        }

        public async Task<Order?> Add(PostOrderDto postOrderDto)
        {
            var rawOrder = _mapper.Map<Order>(postOrderDto);
            rawOrder.Id = Guid.NewGuid();
            var searchAddress = await _uow.AddressRepo.GetByIdAsync(postOrderDto.Address.Id);
            if (searchAddress == null)
            {
                rawOrder.Address = _mapper.Map<Address>(rawOrder.Address);
                rawOrder.Address.CustomerAccountId = postOrderDto.CustomerId;
            }
            else
            {
                rawOrder.AddressId = postOrderDto.Address.Id ?? Guid.Empty;
                rawOrder.Address = null;
            }

            await _uow.OrderRepo.CreateAsync(rawOrder);

            var serviceToAdd = _mapper.Map<ServiceDto>(await MapServiceRequirementsWithIcon(postOrderDto.Services));
            var addedService = AddService(serviceToAdd, rawOrder.Id, rawOrder);

            if (addedService != null) await _uow.ServiceRepo.CreateAsync(addedService);

            // Save changes within the transaction scope
            if (!await _uow.SaveChangesAsync()) return null;

            return rawOrder;
        }

        public async Task<IEnumerable<GetOrderDto>> GetFreelancerSuitableOrders(Guid freelancerId, FilterFreelancerOrderQuery filterQuery)
        {
            var result = await _uow.OrderRepo.GetFreelancerSuitableOrders(freelancerId, filterQuery);

            return result.Select(_mapper.Map<GetOrderDto>);
        }

        public async Task<Order?> GetById(Guid orderId)
            => await _uow.OrderRepo.GetByIdAsync(orderId);

        public async Task<GetOrderDto?> GetOrderDetailById(Guid id)
        {
            var rawOrder = await _uow.OrderRepo.GetOrderDetailByIdAsync(id);
            if (rawOrder == null) return null;

            var order = _mapper.Map<GetOrderDto>(rawOrder);
            //order.ServiceTypes = rawOrder.OrderServiceTypes?.Select(ost => _mapper.Map<GetServiceTypeDto>(ost.ServiceType)).ToList();

            return order;
        }

        public async Task<IEnumerable<GetCustomerOrderDto>> GetAllCustomerOrders(Guid customerId, FilterCustomerOrderQuery orderQuery)
        {
            var rawOrders = await _uow.OrderRepo.GetCustomerOrders(customerId, orderQuery);
            var result = _mapper.Map<IEnumerable<GetCustomerOrderDto>>(rawOrders);
            foreach (var item in result)
            {
                if (item.ServiceStatusId.Equals(StatusConst.OnMatching))
                {
                    var freelancers = await _uow.BiddingOrderRepo.GetMatchingFreelancersByOrderId(item.Id);
                    item.NumberOfPricing = freelancers.Count();
                }
                else
                {
                    item.NumberOfPricing = 0;
                }
            }

            return result;
        }

        public async Task<GetOrderDto?> GetLatestCustomerOrders(Guid customerId)
        {
            var rawOrder = await _uow.OrderRepo.GetLatestCustomerOrders(customerId);

            if (rawOrder is null)
            {
                return null;
            }

            var order = _mapper.Map<GetOrderDto>(rawOrder);
            // order.ServiceTypes = rawOrder.OrderServiceTypes?.Select(ost => _mapper.Map<GetServiceTypeDto>(ost.ServiceType)).ToList();

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrderTest()
        {
            var res = await _uow.OrderRepo.GetAllOrderWithDetailAsync();
            return res;
        }

        public async Task<IEnumerable<GetOrderDto>> GetAllOrder(FilterOrderQuery filterOrderQuery)
        {
            var res = await _uow.OrderRepo.GetOrderWithDetailAsync(filterOrderQuery);
            return res.Select(_mapper.Map<GetOrderDto>);
        }

        public async Task<UpdateOrderResultDto> PostOrderReview(PostOrderCustomerReviewDto review, Guid customerId)
        {
            var order = await _uow.OrderRepo.GetByConditionsAsync(o =>
                o.Id.Equals(review.OrderId)
                && o.CustomerId.Equals(customerId)
                && !o.ServiceStatusId.Equals(StatusConst.Canceled));

            if (order == null)
            {
                return new()
                {
                    Message = "Không tìm thấy đơn đặt hàng"
                };
            }
            if (order.FreelancerId == null)
            {
                return new()
                {
                    Message = "Đơn đặt hàng của bạn chưa được nhận bởi Freelancer"
                };
            }
            if (order.Rating != 0)
            {
                return new()
                {
                    Message = "Đơn đặt hàng của bạn đã được review."
                };
            }

            order.Rating = review.Rating;
            order.Comment = review.Comment;
            var orderNew = await _uow.OrderRepo.UpdateAsync(order);

            return new()
            {
                Order = orderNew,
                Message = "Đánh giá đơn hàng thành công",
            };
        }

        public async Task<UpdateOrderResultDto> PostCancelOrderCustomer(Guid orderId, Guid customerId)
        {
            var validStatusList = new List<Guid>()
            {
                StatusConst.Created, StatusConst.OnMatching, StatusConst.Waiting, StatusConst.Canceled
            };

            var order = await _uow.OrderRepo.GetByConditionsAsync(o =>
                o.Id.Equals(orderId)
                && o.CustomerId.Equals(customerId)
                // && o.FreelancerId == null
                && validStatusList.Any(item => o.ServiceStatusId.Equals(item)));

            if (order == null)
            {
                return new()
                {
                    Message = "Không tìm thấy đơn đặt hàng cần hủy. Hãy kiểm tra lại trạng thái đơn"
                };
            }

            order.ServiceStatusId = StatusConst.Canceled;
            var orderNew = await _uow.OrderRepo.UpdateAsync(order);

            return new()
            {
                Order = orderNew,
                Message = "Hủy đơn hàng thành công"
            };
        }

        public async Task<IEnumerable<GetOrderDto>> GetFreelancerIncomingOrders(Guid freelancerId)
        {
            var res = await _uow.OrderRepo.GetFreelancerIncomingOrdersAsync(freelancerId);

            return _mapper.Map<IEnumerable<GetOrderDto>>(res);
        }

        public async Task<UpdateOrderResultDto> PostFreelancerReview(PostOrderFreelancerReviewDto review, Guid freelancerId)
        {
            var order = await _uow.OrderRepo.GetByConditionsAsync(o =>
                o.Id.Equals(review.OrderId)
                && o.FreelancerId.Equals(freelancerId)
                && !o.ServiceStatusId.Equals(StatusConst.Canceled));

            if (order == null)
            {
                return new()
                {
                    Message = "Không tìm thấy đơn đặt hàng"
                };
            }
            if (order.FreelancerRating != 0)
            {
                return new()
                {
                    Message = "Bạn đã review cho đơn này."
                };
            }

            order.FreelancerRating = review.Rating;
            order.FreelancerComment = review.Comment;

            if (!await _uow.SaveChangesAsync())
            {
                return new()
                {
                    Message = "Có lỗi xảy ra trong lúc đánh giá đơn."
                };
            }

            return new()
            {
                Order = order,
                Message = "Đánh giá đơn hàng thành công",
            };
        }
    }
}
