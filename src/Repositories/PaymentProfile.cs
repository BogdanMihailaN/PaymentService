using AutoMapper;
using PaymentService.Domain.Models;

namespace PaymentService.Repositories
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Domain.Entities.Payment, PaymentModel>();
            CreateMap<PaymentModel, Domain.Entities.Payment>();
        }
    }
}
