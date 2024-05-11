using DeToiServer.Dtos.AddressDtos;
using DeToiServer.Dtos.CustomerDtos;
using DeToiServer.Dtos.FreelanceDtos;
using DeToiServer.Dtos.ServiceDtos;
using DeToiServer.Dtos.ServiceStatusDtos;
using DeToiServer.Dtos.ServiceTypeDtos;
using DeToiServer.Dtos.SkillDtos;
using System.Text.Json.Serialization;

namespace DeToiServer.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public Guid Id { get; set; }
        public ICollection<AddressDto> Address { get; set; } = null!;
        public double EstimatedPrice { get; set; }
        public double PreviewPrice { get; set; }
        public double RecommendPrice { get; set; }
        public string? BiddingNote { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly FinishTime { get; set; }
        public DateOnly FinishDate { get; set; }
        public GetCustomerAccountDto? Customer { get; set; }
        [JsonPropertyName("freelancer")]
        public GetFreelanceAccountInOrderDto? Freelance { get; set; }
        public bool IsCustomerRated { get; set; }
        public string ServiceStatus { get; set; } = string.Empty;
        public ICollection<GetServiceTypeDto>? ServiceTypes { get; set; }
        public ICollection<SkillDto>? SkillRequired { get; set; }
        public ServiceDto Services { get; set; } = null!;
        public ICollection<GetServiceStatusDto> ServiceStatusList { get; set; } = null!;
    }

    public class GetCustomerOrderDto
    {
        public Guid Id { get; set; }
        public ICollection<AddressDto> Address { get; set; } = null!;
        public double EstimatedPrice { get; set; }
        public double PreviewPrice { get; set; }
        public double RecommendPrice { get; set; }
        public int QuotedFreelancerCount { get; set; }
        public TimeOnly StartTime { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly FinishTime { get; set; }
        public DateOnly FinishDate { get; set; }
        public GetCustomerAccountDto? Customer { get; set; }
        [JsonPropertyName("freelancer")]
        public GetFreelanceAccountInOrderDto? Freelance { get; set; }
        public bool IsCustomerRated { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public Guid ServiceStatusId { get; set; }
        public string ServiceStatus { get; set; } = string.Empty;
        public ICollection<GetServiceTypeDto>? ServiceTypes { get; set; }
        public ICollection<SkillDto>? SkillRequired { get; set; }
        public required ServiceDto Services { get; set; }
        public ICollection<GetServiceStatusDto> ServiceStatusList { get; set; } = null!;
    }
}
