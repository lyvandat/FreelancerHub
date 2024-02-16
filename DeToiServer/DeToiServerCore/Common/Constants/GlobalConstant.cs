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

        
    }

    public static class StatusConst
    {
        public const string Waiting = "Waiting";
        public const string OnMoving = "OnMoving";
        public const string OnDoingService = "OnDoingService";
        public const string Completed = "Completed";
        public const string Reported = "Reported";

        public static readonly List<string> OrderStatus = [
            Waiting,
            OnMoving,
            OnDoingService,
            Completed,
            Reported,
        ];
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
