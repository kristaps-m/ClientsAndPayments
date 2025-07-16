using ClientsAndPayments.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientsAndPayments.Data
{
    public class ClientsAndPaymentsDbContext : DbContext, IClientsAndPaymentsDbContext
    {
        public ClientsAndPaymentsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Client> Clients { get; set; }


        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Payments)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
