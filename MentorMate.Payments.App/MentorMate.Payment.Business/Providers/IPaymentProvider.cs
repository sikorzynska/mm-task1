namespace MentorMate.Payment.Business.Providers
{
    public interface IPaymentProvider
    {
        public bool ProcessPayment(Models.Payment payment);
    }
}
