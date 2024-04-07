﻿using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.ServiceDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.SkillDtos;
using System.Text.Json.Serialization;

namespace DeToiServer.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }
        public AddressDto? Address { get; set; }
        public double EstimatedPrice { get; set; }
        public double PreviewPrice { get; set; }
        public double RecommendPrice { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly FinishTime { get; set; }
        public DateOnly FinishDate { get; set; }
        [JsonPropertyName("freelancer")]
        public GetFreelanceAccountInOrderDto? Freelance { get; set; }
        public string ServiceStatus { get; set; } = string.Empty;
        public ICollection<GetServiceTypeDto>? ServiceTypes { get; set; }
        public ICollection<SkillDto>? SkillRequired { get; set; }
        public required ServiceDto Services { get; set; }
    }
}
