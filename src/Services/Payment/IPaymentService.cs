using PaymentService.Domain.Models;

namespace PaymentService.Services.Payment
{
    public interface IPaymentService
    {
        Task<PaymentModel> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentModel>> GetAllPaymentsAsync();
        Task<int> CreatePaymentAsync(PaymentModel payment);
        Task DeletePaymentAsync(int id);
    }
}
