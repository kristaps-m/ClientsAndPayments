using ClientsAndPayments.Core.Models;

namespace ClientsAndPayments.Core.Interfaces
{
    public interface IClientService:IEntityService<Client>
    {
        PagedResult<Client> GetPagedClients(string? search, int page = 1, int pageSize = 10);
    }
}
