namespace DeToiServerCore.Common.Constants
{
    public static class GlobalConstant
    {
        public const string Customer = "Customer";
        public const string Freelancer = "Freelancer";
        public const string Admin = "Admin";

        public static readonly List<string> Roles =
        [
            Customer,
            Freelancer,
            Admin
        ];

        public const string CustomerAvtMale = "https://detoivn.b-cdn.net/customer_avt/user-avt%20(2).png";
        public const string DefaultCommentAvt = "https://detoivn.b-cdn.net/customer_avt/user-avt%20(2).png";
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
            public static readonly string CoD = "CoD";
            public static readonly string MoMo = "Momo";
            public static readonly string Card = "Card";

            public static class Wallet {
                public static readonly string Personal = "Personal";
                public static readonly string System = "System";
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
            {Waiting, 0},
            {OnMoving, 1},
            {OnDoingService, 2},
            {Completed, 3},
        };
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
