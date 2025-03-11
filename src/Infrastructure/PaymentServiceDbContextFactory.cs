using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PaymentService.Infrastructure
{
    public class PaymentServiceDbContextFactory : IDesignTimeDbContextFactory<PaymentServiceDbContext>
    {
        public PaymentServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentServiceDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=PaymentServiceDb;TrustServerCertificate=True;Integrated Security=True;");

            return new PaymentServiceDbContext(optionsBuilder.Options);
        }
    }
}
