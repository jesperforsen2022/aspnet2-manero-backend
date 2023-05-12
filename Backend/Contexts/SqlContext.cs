using Backend.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Backend.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddressEntity>().HasKey(or => new { or.UserId, or.AddressId });
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }
        public DbSet<CreditCardEntity> CreditCards { get; set;}
        public DbSet<RoleEntity> Roles { get; set; }
    }
}
