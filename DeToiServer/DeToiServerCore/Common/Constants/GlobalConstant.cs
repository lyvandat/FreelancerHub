namespace DeToiServerCore.Common.Constants
{
    public static class GlobalConstant
    {
        public const string Customer = "Customer";
        public const string Freelancer = "Freelancer";
        public const string UnverifiedFreelancer = "UnverifiedFreelancer";
        public const string Admin = "Admin";

        public enum ERole
        {
            Customer,
            Freelancer,
            Admin
        };

        public static readonly List<string> Roles =
        [
            Customer,
            Freelancer,
            Admin
        ];

        public const string CustomerAvtMale = "customer_avt/default_customer_1.jpg";
        public const string DefaultCommentAvt = "customer_avt/default_customer_2.jpg";
        public const string DefaultCommentContent = "Người dùng không nhận xét.";
        public const int InMeters = 1000;
        public const int InKilometers = 1;
        public const string GeoCodeDefault = "Dữ liệu bản đồ chưa có.";
        public const int DefaultDelayTime = 1000;

        public static class Order
        {
            public static readonly double DefaultRecommendPrice = 100000d;
        }

        public static class Payment
        {
            public static Dictionary<string, string> PaymentTypeDictionary = new()
            {
                { "MoMo", "Nạp tiền vào ví cá nhân với ví điện tử Momo" },
                { "Card", "Nạp tiền vào ví cá nhân với thẻ ngân hàng" },
                { "AppFee", "Hệ thống trừ tiền hoa hồng dịch vụ" },
                { "Withdrawal", "Rút toàn bộ tiền khỏi tài khoản" },

            };

            public static readonly string MoMo = "Momo";
            public static readonly string Card = "Card";
            public static readonly string AppFee = "AppFee"; // we charge a small commision fee on freelancers' wallet
            public static readonly string Withdrawal = "AppFee"; // Freelancers leave and withdraw money

            public static class Wallet {
                public static readonly string Personal = "Personal";
                public static readonly string System = "System";
            }

            public static class Description
            {

            }
        }

        public static class SqlFiles
        {
            public static readonly string DataFile = "insert_data.sql";
        }

        public static class Quiz
        {
            public static class QuestionType
            {
                public static readonly string SingleChoice = "SingleChoice";
                public static readonly string MultipleChoice = "MultipleChoice";
            }
        }

        public static class Requirement
        {
            public static readonly string DefaultRequirementIcon = "faNoteSticky";
        }

        public static class Review
        {
            public static readonly DateTime DefaultDateTime = new(2024, 1, 1);
        }

        public static class Gender
        {
            public static readonly string Male = "Male";
            public static readonly string Female = "Female";
        }

        public static class Notification
        {
            public static readonly string CustomerChooseThisFreelancer = "CUSTOMER_CHOSE_THIS_FREELANCER";
            public static readonly string CustomerNotChooseThisFreelancer = "CUSTOMER_NOT_CHOSE_THIS_FREELANCER";
            public static readonly string FreelancerQuoteServiceToCustomer = "FREELANCER_QUOTE_SERVICE_TO_CUSTOMER";
            public static readonly string FreelancerCanceledOrder = "FREELANCER_CANCELED_ORDER";
            public static readonly string CustomerCanceledOrder = "CUSTOMER_CANCELED_ORDER";
            public static readonly int TimeSpan = 30;
        }

        public static class Report
        {
            public readonly static Guid NoAction = Guid.Parse("57779da0-5c1e-43d0-92c8-35ad09735667");
            public readonly static Guid RefundAll = Guid.Parse("558aeed2-8609-4f8d-9a27-57f36e3c9062");
            public readonly static Guid RefundHalf = Guid.Parse("39cff80d-a7b4-4ef1-899d-a1b4fef74b80"); 
            public readonly static Guid BanCustomer = Guid.Parse("00ecac93-4e33-4145-b72a-787893f68a84");
            public readonly static Guid BanFreelancer = Guid.Parse("aadbe15c-882f-4a3b-bd76-e017eee11027"); 
            public readonly static Guid MarkFreelancer = Guid.Parse("afdc03f7-f266-4031-ae34-223abad7b771");

            public readonly static int MarkToBan = 3;
        }

        public static class AddressOption
        {
            public static readonly string None = "none";
            public static readonly string Destination = "destination";
            public static readonly string Shipping = "shipping";
            public enum ShippingEnum { From, To }
            public enum DestinationEnum { Place }
        }

        public static class Fee
        {
            public static readonly string PlatformFee = "Platform";
            public static readonly string MinServicePrice = "MinServicePrice";

            public static class Id
            {
                public static readonly Guid PlatformFee = Guid.Parse("4165cef1-7486-45d6-9ce1-677dc35956d5");
                public static readonly Guid MinServicePrice = Guid.Parse("3e85a38f-21e3-43e8-9ecb-1d697a9cebf1");
            }

            public static class ValueConst
            {
                public static readonly double PlatformFee = 0.05;
                public static readonly double MinServicePrice = 50000.0;
            }
        }
    }

    public static class StatusConst
    {
        public readonly static Guid Created = Guid.Parse("a888efc3-1d7b-445a-b38c-758737b67bad");
        public readonly static Guid OnMatching = Guid.Parse("a53e9887-2186-4ff8-a009-f7706c800b52");
        public readonly static Guid Waiting = Guid.Parse("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd");
        public readonly static Guid OnMoving = Guid.Parse("0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2");
        public readonly static Guid OnDoingService = Guid.Parse("3f98b502-7245-4e86-b7b4-7db05357a1f8");
        public readonly static Guid Completed = Guid.Parse("a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32");
        public readonly static Guid Canceled = Guid.Parse("0774e101-f1a3-4186-af1e-af95a26e9ead");


        public static Dictionary<Guid, int> StatusConstOrder = new Dictionary<Guid, int>()
        {
            {Canceled, -1},
            {Created, 0},
            {OnMatching, 1},
            {Waiting, 2},
            {OnMoving, 3},
            {OnDoingService, 4},
            {Completed, 5},
        };

        public static readonly IEnumerable<Guid> StatusIdCollections = [
            Created,
            OnMatching,
            Waiting,
            OnMoving,
            OnDoingService,
            Completed,
            Canceled,
        ];
    }

    public static class ReportConst
    {
        public readonly static Guid New = Guid.Parse("a888efc3-1d7b-445a-b38c-758737b67bad");
        public readonly static Guid Handled = Guid.Parse("a53e9887-2186-4ff8-a009-f7706c800b52");

        public static class Actions
        {
            public readonly static Guid Rejected = Guid.Parse("8a9f22f1-3c67-49f7-bd84-ec290e4a37fd");
            public readonly static Guid BanCustomer = Guid.Parse("0815e9cf-98c7-4a6a-b27b-43d9b8d1f5a2");
            public readonly static Guid BanFreelancer = Guid.Parse("3f98b502-7245-4e86-b7b4-7db05357a1f8");
            public readonly static Guid MarkFreelancer = Guid.Parse("a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32");
            public readonly static Guid Canceled = Guid.Parse("0774e101-f1a3-4186-af1e-af95a26e9ead");
        }



        //public static Dictionary<Guid, int> StatusConstOrder = new Dictionary<Guid, int>()
        //{
        //    {Canceled, -1},
        //    {Waiting, 0},
        //    {OnMoving, 1},
        //    {OnDoingService, 2},
        //    {Completed, 3},
        //};
    }

    public static class CustomerRankConst
    {
        public const string Unranked = "Unranked";
        public const string Bronze = "Bronze";

        public static readonly List<string> Ranks = [
            Bronze
        ];
    }

    public static class DiscountTypeConst
    {
        public const string Direct = "Direct";
        public const string Percentage = "Percentage";

        public static readonly List<string> Types = [
            Direct,
            Percentage
        ];
    }

    public static class LoginProviders
    {
        public const string Google = "GOOGLE";
        public const string Facebook = "FACEBOOK";
    }
}
