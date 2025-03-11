using PaymentService.Domain.Models;

namespace PaymentService.Repositories.Payment
{
    public interface IPaymentRepository
    {
        Task<PaymentModel> GetPaymentByIdAsync(int id);
        Task<IEnumerable<PaymentModel>> GetAllPaymentsAsync();
        Task AddPaymentAsync(PaymentModel payment);
        Task DeletePaymentAsync(int id);
    }
}
