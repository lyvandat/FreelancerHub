using DeToiServer.Models;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Quiz;
using DeToiServerCore.Models.Payment;
using DeToiServerCore.Models.Services;
using DeToiServerCore.Models.SevicesUIElement;
using DeToiServerData.Configurations;
using Microsoft.EntityFrameworkCore;
using DeToiServerCore.Models.Notifications;
using DeToiServerCore.Models.Reports;
using DeToiServerCore.Models.Chat;

namespace DeToiServerData
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new FreelancePaymentConfiguration());
            modelBuilder.ApplyConfiguration(new FreelancerSkillConfiguration());
            modelBuilder.ApplyConfiguration(new FreelancerServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SkillServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderSkillRequireTypeConfiguration());

            // Service
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceStatusConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new BiddingOrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderServiceConfiguration());
            
            modelBuilder.ApplyConfiguration(new OrderServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeStatusConfiguration());
            modelBuilder.ApplyConfiguration(new OrderAddressConfiguration());

            // Blogs
            modelBuilder.ApplyConfiguration(new TermOfServiceConfiguration());
            modelBuilder.ApplyConfiguration(new FrequentlyAskedQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration());

            // Promotion
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerPromotionConfiguration());

            #region UI_Element_Config
            modelBuilder.ApplyConfiguration(new UIElementInputMethodTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementInputOptionConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementOptionInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementOptionInfoValidationConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementServiceRequirementInputMethodConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementValidationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementServiceRequirementConfiguration());
            modelBuilder.ApplyConfiguration(new UIElementAdditionServiceRequirementConfiguration());
            #endregion

            #region Realtime config
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            #endregion

            #region Freelancer Quiz Config
            modelBuilder.ApplyConfiguration(new QuizQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceQuizQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceQuizAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceQuizConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceCorrectQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceQuizResultConfiguration());
            #endregion

            #region Notification Config
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationAccountConfiguration());
            #endregion

            #region Report Config
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ReportActionConfiguration());
            modelBuilder.ApplyConfiguration(new ReportImageConfiguration());
            modelBuilder.Entity<ApplyReportAction>().HasNoKey()
                .ToTable("ApplyReportActions", t => t.ExcludeFromMigrations());

            #endregion

            #region Fee Config
            modelBuilder.ApplyConfiguration(new FeeConfiguration());
            #endregion

            #region Message Config
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            #endregion
        }

        // Account related models
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FreelanceAccount> Freelancers { get; set; }
        public DbSet<CustomerAccount> Customers { get; set; }
        public DbSet<AdminAccount> Admins { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<FreelancePaymentHistory> FreelancePaymentHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationAccount> NotificationAccounts { get; set; }

        public DbSet<FreelanceSkill> FreelanceSkills { get; set; }
        public DbSet<FreelanceServiceType> FreelanceServiceTypes { get; set; }
        public DbSet<SkillServiceType> SkillServiceTypes { get; set; }
        public DbSet<OrderSkillRequired> OrderSkillsRequired { get; set; }
        

        // Service related models
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAddress> OrderAddresses { get; set; }
        public DbSet<OrderServiceType> OrderServiceTypes { get; set; }
        public DbSet<PaymentStatusHistory> PaymentHistories { get; set; }
        public DbSet<BiddingOrder> BiddingOrders { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceTypeStatus> ServiceTypeStatuses { get; set; }

        #region Service_UI_Element
        public DbSet<UIElementValidationType> UIElementValidationTypes { get; set; }
        public DbSet<UIElementInputOption> UIElementInputOptions { get; set; }
        public DbSet<UIElementOptionInfo> UIElementInputOptionInfos { get; set; }
        public DbSet<UIElementOptionInfoValidation> UIElementInputOptionInfoValidations { get; set; }
        public DbSet<UIElementInputMethodType> UIElementInputMethodTypes { get; set; }
        public DbSet<UIElementServiceRequirementInputMethod> UIElementServiceRequirementInputMethods { get; set; }
        public DbSet<UIElementServiceRequirement> UIElementServiceRequirements { get; set; }
        public DbSet<UIElementAdditionServiceRequirement> UIElementAdditionServiceRequirements { get; set; }
        #endregion

        #region Content_related_models
        public DbSet<TermOfService> TermOfServices { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
        #endregion

        #region Promotion_models
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<CustomerPromotion> CustomerPromotions { get; set; }
        #endregion

        #region Realtime
        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }
        #endregion

        #region Quiz
        public DbSet<FreelanceQuiz> FreelanceQuizzes { get; set; }
        public DbSet<FreelanceQuizQuestion> FreelanceQuizQuestions { get; set; }
        public DbSet<FreelanceQuizAnswer> FreelanceQuizAnswers { get; set; }
        public DbSet<FreelanceCorrectQuestion> FreelanceCorrectQuestions { get; set; }
        public DbSet<FreelanceQuizResult> FreelanceQuizResults { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        #endregion

        #region Report
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportAction> ReportActions { get; set; }
        public DbSet<ReportImage> ReportImages { get; set; }
        #endregion

        #region Fee
        public DbSet<Fee> Fees { get; set; }
        #endregion

        #region Message
        public DbSet<Message> Messages { get; set; }
        #endregion
    }
}