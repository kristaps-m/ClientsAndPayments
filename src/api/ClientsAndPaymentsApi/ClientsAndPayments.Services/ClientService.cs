using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Core.Models;
using ClientsAndPayments.Data;

namespace ClientsAndPayments.Services
{
    public class ClientService: EntityService<Client>, IClientService
    {
        public ClientService(IClientsAndPaymentsDbContext context) : base(context){ }

        public PagedResult<Client> GetPagedClients(string? search, int page = 1, int pageSize = 10)
        {
            var query = _context.Clients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(c =>
                    c.Name.ToLower().Contains(search) ||
                    c.Email.ToLower().Contains(search));
            }

            var totalCount = query.Count();

            var clients = query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<Client>
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                Data = clients
            };
        }
    }
}
