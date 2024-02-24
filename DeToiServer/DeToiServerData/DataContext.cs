using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Infos;
using DeToiServerCore.Models.Services;
using DeToiServerData.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

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
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new FreelanceConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceStatusConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderServiceConfiguration());
            modelBuilder.ApplyConfiguration(new CleaningServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingServiceConfiguration());
            modelBuilder.ApplyConfiguration(new RepairingServiceConfiguration());

            modelBuilder.ApplyConfiguration(new TermOfServiceConfiguration());
            modelBuilder.ApplyConfiguration(new FrequentlyAskedQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration());

            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerPromotionConfiguration());
        }

        // Account related models
        public DbSet<Account> Accounts { get; set; }
        public DbSet<FreelanceAccount> Freelancers { get; set; }
        public DbSet<CustomerAccount> Customers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // Service related models
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<CleaningService> CleaningServices { get; set; }
        public DbSet<RepairingService> RepairingServices { get; set; }
        public DbSet<ShoppingService> ShoppingServices { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<HomeInfo> HomeInfo { get; set; }
        public DbSet<DeviceInfo> DeviceInfo { get; set; }
        public DbSet<ShoppingInfo> ShoppingInfo { get; set; }

        #region Content_related_models
        public DbSet<TermOfService> TermOfServices { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
        #endregion

        #region Promotion_models
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<CustomerPromotion> CustomerPromotions { get; set; }
        #endregion
    }
}
