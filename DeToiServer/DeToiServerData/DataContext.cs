using DeToiServerCore.Models;
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

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.HasKey(e => e.Id).HasName("fk_accounts");

                entity.Property(e => e.Email).HasMaxLength(255);
                //entity.Property(e => e.FullName).HasMaxLength(255);
                //entity.Property(e => e.PasswordHash).HasMaxLength(512);
                //entity.Property(e => e.PasswordResetToken).HasMaxLength(512);
                //entity.Property(e => e.PasswordSalt).HasMaxLength(512);
                //entity.Property(e => e.Phone).HasMaxLength(12);
                //entity.Property(e => e.RefreshToken).HasMaxLength(512);
                //entity.Property(e => e.Role).HasMaxLength(12);
            });
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
