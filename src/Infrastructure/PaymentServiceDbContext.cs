using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;

namespace PaymentService.Infrastructure
{
    public class PaymentServiceDbContext : DbContext
    {
        public PaymentServiceDbContext(DbContextOptions<PaymentServiceDbContext> options)
            : base(options)
        { }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed pentru PaymentMethod
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = 1, Name = "Credit Card", Description = "Plată cu cardul de credit" },
                new PaymentMethod { Id = 2, Name = "PayPal", Description = "Plată prin PayPal" },
                new PaymentMethod { Id = 3, Name = "Bank Transfer", Description = "Plată prin transfer bancar" }
            );

            // Seed pentru PaymentStatus
            modelBuilder.Entity<PaymentStatus>().HasData(
                new PaymentStatus { Id = 1, Status = "Pending" },
                new PaymentStatus { Id = 2, Status = "Completed" },
                new PaymentStatus { Id = 3, Status = "Failed" }
            );

            // Seed pentru Payment (valori exemplu pentru început)
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 100.00m,
                    PaymentDate = new DateTime(2025, 03, 10),
                    Currency = "RON",
                    UserId = 1,  // Asigură-te că ai un utilizator cu ID-ul 1
                    PaymentMethodId = 1,  // Card de credit
                    PaymentStatusId = 2  // Completed
                },
                new Payment
                {
                    Id = 2,
                    Amount = 200.00m,
                    PaymentDate = new DateTime(2025, 03, 10),
                    Currency = "RON",
                    UserId = 2,  // Asigură-te că ai un utilizator cu ID-ul 2
                    PaymentMethodId = 2,  // PayPal
                    PaymentStatusId = 1  // Pending
                }
            );
        }
    }
}
