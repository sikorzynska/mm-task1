namespace MentorMate.Payment.Business.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
