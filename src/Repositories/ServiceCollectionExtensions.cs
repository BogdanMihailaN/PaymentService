using Microsoft.Extensions.DependencyInjection;
using PaymentService.Repositories.Payment;

namespace PaymentService.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
