using Microsoft.AspNetCore.Mvc;
using PaymentService.Domain.Models;
using PaymentService.Services.Payment;

namespace PaymentService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentAsync(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaymentsAsync()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentAsync([FromBody] PaymentModel paymentDto)
        {
            var paymentId = await _paymentService.CreatePaymentAsync(paymentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentAsync(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
