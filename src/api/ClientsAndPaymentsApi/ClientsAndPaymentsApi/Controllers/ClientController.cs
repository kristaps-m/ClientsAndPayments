using ClientsAndPayments.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientsAndPaymentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _clientService.GetAll();
            return Ok(entities);
        }
    }
}
