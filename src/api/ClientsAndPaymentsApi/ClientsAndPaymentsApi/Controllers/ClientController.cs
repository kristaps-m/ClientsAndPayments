using ClientsAndPayments.Core.DataTransverModels;
using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientsAndPaymentsApi.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAll(string? search, int page = 1, int pageSize = 10)
        {
            var result = _clientService.GetPagedClients(search, page, pageSize);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateClient(CreateClientDto clientDto)
        {
            var client = new Client
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                RegistredAt = DateTime.UtcNow.AddHours(-2)
            };

            _clientService.Create(client);

            return Created("Client created!", client);
        }
    }
}
