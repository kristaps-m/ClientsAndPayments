using ClientsAndPayments.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientsAndPaymentsApi.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("recent")]
        public IActionResult GetLatestPayments()
        {
            var latest20Payments = _paymentService.GetLatest20Payments();

            return Ok(latest20Payments);
        }

        //[Route("all")]
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var entities = _paymentService.GetAll();
        //    return Ok(entities);
        //}
    }
}
