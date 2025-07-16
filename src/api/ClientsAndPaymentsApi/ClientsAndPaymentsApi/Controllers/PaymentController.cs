using ClientsAndPayments.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientsAndPaymentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _paymentService.GetAll();
            return Ok(entities);
        }
    }
}
