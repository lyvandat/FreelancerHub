using DeToiServerCore.Models;
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
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
