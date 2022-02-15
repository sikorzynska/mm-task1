using System.Text;

namespace MentorMate.Payment.Business.Providers
{
    public class PayPalPaymentProvider : IPaymentProvider
    {
        public bool ProcessPayment(Models.Payment payment)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Payment provider: PayPal");
            sb.AppendLine($"Payment amount: ${payment.Amount:f2}");
            sb.AppendLine($"Reason for payment: {payment.Description}");

            Console.WriteLine(sb.ToString().TrimEnd());

            return true;
        }
    }
}
