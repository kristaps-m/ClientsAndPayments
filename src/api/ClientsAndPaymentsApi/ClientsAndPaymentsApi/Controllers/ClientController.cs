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

        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _clientService.GetAll();
            return Ok(entities);
        }

        [HttpPost]
        public IActionResult CreateClient(Client client)
        {
            _clientService.Create(client);

            return Created("Client created!", client);
        }
    }
}
