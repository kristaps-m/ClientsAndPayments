using ClientsAndPayments.Core.DataTransverModels;
using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Core.Models;
using ClientsAndPayments.Data;

namespace ClientsAndPayments.Services
{
    public class ClientService: EntityService<Client>, IClientService
    {
        public ClientService(IClientsAndPaymentsDbContext context) : base(context){ }

        //public PagedResult<ReturnClientDto> GetPagedClients(string? search, int page = 1, int pageSize = 10)
        //{
        //    var query = _context.Clients.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(search))
        //    {
        //        search = search.ToLower();
        //        query = query.Where(c =>
        //            c.Name.ToLower().Contains(search) ||
        //            c.Email.ToLower().Contains(search));
        //    }

        //    var totalCount = query.Count();

        //    var clients = query
        //        .OrderBy(c => c.Name)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .Select(c => new ReturnClientDto
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //            Email = c.Email,
        //            RegistredAt = c.RegistredAt
        //        })
        //        .ToList();

        //    var totalPaidSum = _context.Payments.AsEnumerable().Sum(p => p.Amount);

        //    return new PagedResult<ReturnClientDto>
        //    {
        //        TotalCount = totalCount,
        //        Page = page,
        //        PageSize = pageSize,
        //        Data = clients,
        //        ClientsTotalPaidAmount = totalPaidSum
        //    };
        //}

        public PagedResult<ReturnClientDto> GetPagedClients(string? search, int page = 1, int pageSize = 10)
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

            var pagedClients = query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var clientIds = pagedClients.Select(c => c.Id).ToList();

            var totalPaidSum = _context.Payments.AsEnumerable()
                .Where(p => clientIds.Contains(p.ClientId))
                .Sum(p => p.Amount);

            var allPayments = _context.Payments.AsEnumerable();

            var clients = pagedClients
                .Select(c => new ReturnClientDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                    RegistredAt = c.RegistredAt,
                    TotalPaid = allPayments
                        .Where(p => p.ClientId == c.Id)
                        .Sum(p => p.Amount)
                })
                .ToList();

            return new PagedResult<ReturnClientDto>
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                Data = clients,
                ClientsTotalPaidAmount = totalPaidSum
            };
        }


        public ClientDetailsAndPayments? GetClientAndTheirPayments(int id)
        {
            var client = _context.Clients.FirstOrDefault((c) => c.Id == id);
            if (client == null) return null;
            
            var payments = _context.Payments
            .Where(p => p.ClientId == id)
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                Amount = p.Amount,
                Currency = p.Currency,
                PaidAt = p.PaidAt,
                Note = p.Note
            })
            .ToList();

            return new ClientDetailsAndPayments
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                RegistredAt = client.RegistredAt,
                TotalAmount = payments.Sum(p => p.Amount),
                Payments = payments
            };
        }

        public List<PaymentDto> GetClientsPayments(int id)
        {
            var payments = _context.Payments
                .Where(p => p.ClientId == id)
                .OrderBy(p => p.PaidAt)
                .Select(p => new PaymentDto
                {
                    Id = p.Id,
                    Amount = p.Amount,
                    Currency = p.Currency,
                    PaidAt = p.PaidAt,
                    Note = p.Note
                }).ToList();

            return payments;
        }
    }
}
