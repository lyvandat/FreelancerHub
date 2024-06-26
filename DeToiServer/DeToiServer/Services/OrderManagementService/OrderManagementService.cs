﻿using AutoMapper;
using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServer.Dtos.ServiceDtos;
using DeToiServer.RealTime;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;
using DeToiServerCore.QueryModels.OrderQueryModels;

namespace DeToiServer.Services.OrderManagementService
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderManagementService> _logger;
        private readonly RealtimeConsumer _consumer;
        private const int MAX_SERVICE = 50;

        public OrderManagementService(
            UnitOfWork uow, 
            IMapper mapper,
            RealtimeConsumer consumer,
            ILogger<OrderManagementService> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _consumer = consumer;
            _logger = logger;
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
            rawOrder.PaymentStatus = PaymentStatus.NotPaid;
            rawOrder.ServiceStatusId = StatusConst.OnMatching;
            if (postOrderDto.IsFastestPossible)
            {
                rawOrder.StartTime = rawOrder.CreatedTime;
            }

            rawOrder.OrderAddress = new List<OrderAddress>() {};
            if (postOrderDto.Address != null)
            {
                foreach (PostOrderAddressDto address in postOrderDto.Address)
                {
                    if (address.Id != null)
                    {
                        rawOrder.OrderAddress.Add(new OrderAddress()
                        {
                            // Order = null!,
                            OrderId = rawOrder.Id,
                            // Address = null!,
                            AddressId = address.Id ?? Guid.Empty
                        });
                    }
                    else
                    {
                        var myAddress = _mapper.Map<Address>(address);
                        myAddress.CustomerAccountId = postOrderDto.CustomerId;
                        rawOrder.OrderAddress.Add(new OrderAddress()
                        {
                            OrderId = rawOrder.Id,
                            // Order = null!,
                            Address = myAddress,
                            // AddressId = Guid.Empty
                        });
                    }
                }
            }

            await _uow.OrderRepo.CreateAsync(rawOrder);

            var serviceToAdd = _mapper.Map<ServiceDto>(await MapServiceRequirementsWithIcon(postOrderDto.Services));
            var addedService = AddService(serviceToAdd, rawOrder.Id, rawOrder);

            if (addedService != null) await _uow.ServiceRepo.CreateAsync(addedService);

            // Save changes within the transaction scope
            if (!await _uow.SaveChangesAsync()) return null;

            //var filerData = await FilterFeasibleFreelancerForOrder(rawOrder.Id);
            //if (filerData != null && filerData.FreelancerPhones != null)
            //{
            //    await _consumer.SendFeasibleOrderToFreelancer(new()
            //    {
            //        FreelancerPhones = filerData.FreelancerPhones,
            //        OrderToSend = _mapper.Map<GetOrderDto>(filerData.OrderDetail),
            //    });
            //}

            return rawOrder;
        }

        private async Task<OrderFeasibleFreelancersQuery> FilterFeasibleFreelancerForOrder(Guid orderId)
        {
            var res = await _uow.OrderRepo.GetSuitableFreelancerForOrderById(orderId);
            return res;
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
                    item.QuotedFreelancerCount = freelancers.Count();
                }
                else
                {
                    item.QuotedFreelancerCount = 0;
                }
            }

            return result;
        }

        public async Task<GetCustomerOrderDto?> GetLatestCustomerOrders(Guid customerId)
        {
            var rawOrder = await _uow.OrderRepo.GetLatestCustomerOrders(customerId);

            if (rawOrder is null)
            {
                return null;
            }

            var freelancers = await _uow.BiddingOrderRepo.GetMatchingFreelancersByOrderId(rawOrder.Id);

            var order = _mapper.Map<GetCustomerOrderDto>(rawOrder);
            order.QuotedFreelancerCount = freelancers.Count();

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
            if (order.IsCustomerRated)
            {
                return new()
                {
                    Message = "Đơn đặt hàng của bạn đã được review."
                };
            }
            if (!order.ServiceStatusId.Equals(StatusConst.Completed))
            {
                return new()
                {
                    Message = "Không thể đánh giá đơn hàng chưa hoàn thành."
                };
            }

            order.Rating = review.Rating;
            order.Comment = review.Comment;
            order.IsCustomerRated = true;
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
                StatusConst.Created, StatusConst.OnMatching, StatusConst.Waiting
            };

            var order = await _uow.OrderRepo.GetByIdWithServiceTypeAsync(orderId);

            if (order == null || !order.CustomerId.Equals(customerId))
            {
                return new()
                {
                    Message = "Không tìm thấy đơn đặt hàng cần hủy. Hãy kiểm tra lại trạng thái đơn"
                };
            }

            if (!validStatusList.Any(item => order.ServiceStatusId.Equals(item)))
            {
                return new()
                {
                    Message = "Không thể hủy đơn hàng này do Freelancer đang thực hiện đơn hàng, vui lòng liên hệ admin để được giải quyết!"
                };
            }

            order.ServiceStatusId = StatusConst.Canceled;

            return new()
            {
                Order = order,
                Message = "Hủy đơn hàng thành công"
            };
        }

        public async Task<UpdateOrderResultWithOldPreviewPriceDto> PostCancelOrderFreelancer(Guid orderId, Guid freelancerId)
        {
            var order = await _uow.OrderRepo.GetByIdWithServiceTypeAsync(orderId);

            if (order == null || !order.FreelancerId.Equals(freelancerId))
            {
                return new()
                {
                    Message = "Không tìm thấy đơn đặt hàng cần hủy. Hãy kiểm tra lại trạng thái đơn"
                };
            }

            var oldPreviewPrice = order.EstimatedPrice;
            order.ServiceStatusId = StatusConst.OnMatching;
            order.EstimatedPrice = 0;
            order.FreelancerId = null;

            return new()
            {
                Order = order,
                OldPreviewPrice = oldPreviewPrice,
                Message = "Hủy đơn hàng thành công"
            };
        }

        public async Task<IEnumerable<GetOrderDto>> GetFreelancerIncomingOrders(FilterFreelancerIncomingOrderQuery query)
        {
            var res = await _uow.OrderRepo.GetFreelancerIncomingOrdersAsync(query);

            return _mapper.Map<IEnumerable<GetOrderDto>>(res);
        }

        public async Task<IEnumerable<GetOrderDto>> GetFreelancerCompletedOrders(FilterFreelancerIncomingOrderQuery query)
        {
            var res = await _uow.OrderRepo.GetFreelancerCompletedOrdersAsync(query);

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
            if (!order.ServiceStatusId.Equals(StatusConst.Completed))
            {
                return new()
                {
                    Message = "Không thể đánh giá đơn hàng chưa hoàn thành."
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

        public async Task<Order?> UpdateStatusAndPostPaymentHistory(PostPaymentStatusHistoryDto paymentStatusHistory)
        {
            var order = await _uow.OrderRepo.GetByIdAsync(paymentStatusHistory.OrderId);
            var paymentStatus = _mapper.Map<PaymentStatusHistory>(paymentStatusHistory);

            if (order == null || paymentStatus == null)
                return null;

            order.PaymentStatus = paymentStatusHistory.PaymentStatus;
            await _uow.PaymentStatusHistoryRepo.CreateAsync(paymentStatus);

            if (!await _uow.SaveChangesAsync())
            {
                _logger.LogError($"Cannot update payment status for order: {paymentStatusHistory.OrderId}");
                return null;
            }

            return order;
        }

        public async Task<UpdateOrderResultDto> UpdateFreelancerFaceImage(Guid freelancerId, PutOrderFreelancerImageDto freelancerImage)
        {
            var order = await _uow.OrderRepo.GetOrderDetailWithFreelancerAsync(freelancerImage.OrderId);

            if (order == null)
                return new()
                {
                    Message = $"Không tìm được đơn với Id={freelancerImage.OrderId}"
                };
            else if (!order.FreelancerId.Equals(freelancerId))
                return new()
                {
                    Message = "Bạn không có quyền cập nhật ảnh cho đơn này."
                };
            else if (!order.ServiceStatusId.Equals(StatusConst.Waiting))
                return new()
                {
                    Message = "Trạng thái đơn không cho phép cập nhật ảnh."
                };


            order.FreelancerFaceImage = freelancerImage.Image;
            return new()
            {
                Order = order,
                Message = "Bạn không có quyền cập nhật ảnh cho đơn này."
            };
        }

        public async Task<Order?> GetByIdWithServiceType(Guid id)
        {
            return await _uow.OrderRepo.GetByIdWithServiceTypeAsync(id);
        }
    }
}
