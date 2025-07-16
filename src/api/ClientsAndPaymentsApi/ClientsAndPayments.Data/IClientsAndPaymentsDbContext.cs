using ClientsAndPayments.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClientsAndPayments.Data
{
    public interface IClientsAndPaymentsDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Client> Clients { get; set; }
        DbSet<Payment> Payments { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}