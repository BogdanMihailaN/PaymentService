namespace PaymentService.Domain.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Currency { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
    }
}
