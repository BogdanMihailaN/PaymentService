using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Models;
using PaymentService.Infrastructure;

namespace PaymentService.Repositories.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentServiceDbContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(PaymentServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentModel> GetPaymentByIdAsync(int id)
        {
            var payment = await _context.Payments.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var paymentModel = _mapper.Map<PaymentModel>(payment);
            return paymentModel;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsAsync()
        {
            var payments = await _context.Payments.ToListAsync();
            var paymentModels = _mapper.Map<List<PaymentModel>>(payments);
            return paymentModels;
        }

        public async Task AddPaymentAsync(PaymentModel payment)
        {
            var paymentEntity = _mapper.Map<Domain.Entities.Payment>(payment);
            await _context.Payments.AddAsync(paymentEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var paymentModel = await GetPaymentByIdAsync(id);
            var payment = _mapper.Map<Domain.Entities.Payment>(paymentModel);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
