using ClientsAndPayments.Core.DataTransverModels;
using ClientsAndPayments.Core.Interfaces;
using ClientsAndPayments.Core.Models;
using ClientsAndPayments.Services;
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
