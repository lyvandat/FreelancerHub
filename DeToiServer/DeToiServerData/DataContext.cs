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
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<OrderService>()
                .HasKey(os => new { os.OrderId, os.ServiceId });

            modelBuilder.Entity<OrderService>()
                .HasOne(os => os.Order)
                .WithMany(o => o.OrderServices)
                .HasForeignKey(os => os.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderService>()
                .HasOne(os => os.Service)
                .WithMany(s => s.OrderServices)
                .HasForeignKey(os => os.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Optionally, set the table name for the joint table
            modelBuilder.Entity<OrderService>().ToTable("OrderService");
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
