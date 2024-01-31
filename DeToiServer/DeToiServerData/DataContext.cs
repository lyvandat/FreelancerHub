using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerCore.Models.Infos;
using DeToiServerCore.Models.Services;
using DeToiServerData.Configurations;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderServiceConfiguration());
            modelBuilder.ApplyConfiguration(new CleaningServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingServiceConfiguration());
            modelBuilder.ApplyConfiguration(new RepairingServiceConfiguration());
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
        public DbSet<CleaningService> CleaningServices { get; set; }
        public DbSet<RepairingService> RepairingServices { get; set; }
        public DbSet<ShoppingService> ShoppingServices { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<HomeInfo> HomeInfo { get; set; }
        public DbSet<DeviceInfo> DeviceInfo { get; set; }
        public DbSet<ShoppingInfo> ShoppingInfo { get; set; }

    }
}
