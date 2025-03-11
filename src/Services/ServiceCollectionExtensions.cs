using Microsoft.Extensions.DependencyInjection;
using PaymentService.Services.Payment;

namespace PaymentService.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPaymentService, Payment.PaymentService>();

            return services;
        }
    }
}
