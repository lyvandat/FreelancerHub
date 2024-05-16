using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.OrderDtos;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Reports;

namespace DeToiServer.Dtos.ReportDtos
{
    public class GetReportDto
    {
        public Guid Id { get; set; }
        public bool Rejected { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public string ResolvingDescription { get; set; } = string.Empty;

        public Guid ActionIdOnCustomer { get; set; } = GlobalConstant.Report.NoAction;
        public ReportAction? ActionOnCustomer { get; set; }
        public Guid ActionIdOnFreelance { get; set; } = GlobalConstant.Report.NoAction;
        public ReportAction? ActionOnFreelance { get; set; }

        public Guid OrderId { get; set; }
        public GetOrderDto? Order { get; set; }

        public Guid FromAccountId { get; set; }
        public GetAccountDto? FromAccount { get; set; }
        public ICollection<GetReportImageDto>? Images { get; set; }
    }

    public class GetReportImageDto
    {
        public required string Image { get; set; }
    }
}
