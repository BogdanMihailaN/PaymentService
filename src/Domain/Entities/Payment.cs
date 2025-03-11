namespace PaymentService.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Currency { get; set; }
        public int UserId { get; set; }

        public int PaymentMethodId { get; set; }  // Metoda de plată
        public PaymentMethod PaymentMethod { get; set; }  // Relația cu metoda de plată

        public int PaymentStatusId { get; set; }  // Statusul plății
        public PaymentStatus PaymentStatus { get; set; }  // Relația cu statusul plății
    }

}
