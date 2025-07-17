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
        private readonly IPaymentService _paymentService;

        public ClientController(IClientService clientService, IPaymentService paymentService)
        {
            _clientService = clientService;
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult GetAll(string? search, int page = 1, int pageSize = 10)
        {
            var result = _clientService.GetPagedClients(search, page, pageSize);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetClientDetails(int id)
        {
            var client = _clientService.GetClientAndTheirPayments(id);

            if (client == null)
                return NotFound($"Client with ID {id} not found.");

            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] CreateClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = new Client
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                RegistredAt = DateTime.UtcNow.AddHours(-2)
            };

            _clientService.Create(client);

            return Created("Client created!", client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient([FromBody] CreateClientDto newClientDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingClient = _clientService.GetById(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Name = newClientDto.Name;
            existingClient.Email = newClientDto.Email;

            _clientService.Update(existingClient);

            return Ok(existingClient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _clientService.GetById(id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            _clientService.Delete(client);

            return NoContent(); // HTTP 204
        }

        [HttpGet("{id}/payments")]
        public IActionResult GetClientsPayments(int id)
        {
            var clientsPayments = _clientService.GetClientsPayments(id);
            if (clientsPayments == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            return Ok(clientsPayments);
        }

        [HttpPost("{id}/payments")]
        public IActionResult AddPayment(int id, [FromBody] CreatePaymentDto paymentDto)
        {
            var client = _clientService.GetById(id);
            if (client == null)
                return NotFound($"Client with ID {id} not found.");

            if (paymentDto.Amount <= 0)
                return BadRequest("Amount must be positive.");

            var payment = new Payment
            {
                ClientId = id,
                Amount = paymentDto.Amount,
                Currency = paymentDto.Currency,
                PaidAt = paymentDto.PaidAt,
                Note = paymentDto.Note
            };

            _paymentService.Create(payment);

            var resultDto = new PaymentDto
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Currency = payment.Currency,
                PaidAt = payment.PaidAt,
                Note = payment.Note
            };

            return Created($"/api/payments/{resultDto.Id}", resultDto);
        }
    }
}
