﻿using DeToiServer.Dtos.AddressDtos;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Services;

namespace DeToiServer.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }
        //public Guid AddressId { get; set; }
        public AddressDto? Address { get; set; }
        public double EstimatedPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public Guid? FreelancerId { get; set; }
        public FreelanceAccount? Freelance { get; set; }
        public Guid? CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public double Rating { get; set; }
        public Guid ServiceStatusId { get; set; } = new Guid("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd");
        public ServiceStatus? ServiceStatus { get; set; }
        public ICollection<OrderService>? OrderServices { get; set; }
        public ICollection<OrderServiceType>? OrderServiceTypes { get; set; }
        public ICollection<ServiceProven>? ServiceProven { get; set; }
    }
}