﻿using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Reports;
using DeToiServerCore.Models.Services;

namespace DeToiServerCore.Models
{
    public enum PaymentStatus
    {
        NotPaid,
        Paid,
        Refunded,
        Failed
    }

    public class Order : ModelBase
    {
        public ICollection<OrderAddress> OrderAddress { get; set; } = null!;
        public double EstimatedPrice { get; set; }
        public double RecommendPrice { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsFastestPossible { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public Guid? FreelancerId { get; set; }
        public FreelanceAccount? Freelance { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerAccount? Customer { get; set; }
        public double Rating { get; set; }
        public string? Comment { get; set; }
        public double FreelancerRating { get; set; } = 0;
        public string? FreelancerComment { get; set; }
        public bool IsCustomerRated { get; set; } = false;
        public string FreelancerFaceImage { get; set; } = GlobalConstant.OrderConst.DefaultImage;
        public Guid ServiceStatusId { get; set; } = new Guid("a888efc3-1d7b-445a-b38c-758737b67bad");
        public ServiceStatus? ServiceStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.NotPaid;
        public ICollection<OrderService>? OrderServices { get; set; }
        public ICollection<OrderServiceType> OrderServiceTypes { get; set; } = null!;
        public ICollection<ServiceProven>? ServiceProven { get; set; }
        public ICollection<BiddingOrder>? BiddingOrders { get; set; }
        public ICollection<OrderSkillRequired>? SkillRequired { get; set; }
        public ICollection<PaymentStatusHistory>? PaymentHistories { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }

    public class PaymentStatusHistory : ModelBase
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public PaymentStatus PaymentStatus { get; set; } // Enum representing payment status
        public DateTime DateChanged { get; set; } = DateTime.Now;
    }
}
