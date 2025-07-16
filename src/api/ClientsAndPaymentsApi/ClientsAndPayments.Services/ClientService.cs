using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Core.Models;
using ClientsAndPayments.Data;

namespace ClientsAndPayments.Services
{
    public class ClientService: EntityService<Client>, IClientService
    {
        public ClientService(IClientsAndPaymentsDbContext context) : base(context)
        {
            
        }
    }
}
