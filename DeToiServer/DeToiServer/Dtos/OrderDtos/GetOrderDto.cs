﻿using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.ServiceTypeDtos;

namespace DeToiServer.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public string AddressLine { get; set; } = string.Empty;
        public double EstimatedPrice { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly FinishTime { get; set; }
        public DateOnly FinishDate { get; set; }
        public GetFreelanceAccountInOrderDto? Freelance { get; set; }
        public string ServiceStatus { get; set; } = string.Empty;
        public ICollection<GetServiceTypeDto>? ServiceTypes { get; set; }
    }
}
