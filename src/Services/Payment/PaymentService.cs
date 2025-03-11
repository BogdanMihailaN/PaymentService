using PaymentService.Domain.Models;
using PaymentService.Repositories.Payment;

namespace PaymentService.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentModel> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            return payment;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return payments;
        }

        public async Task<int> CreatePaymentAsync(PaymentModel payment)
        {
            await _paymentRepository.AddPaymentAsync(payment);
            return payment.Id;
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
        }
    }
}
