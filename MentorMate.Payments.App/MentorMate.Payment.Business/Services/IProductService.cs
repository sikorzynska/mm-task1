namespace MentorMate.Payment.Business.Services
{
    public interface IProductService
    {
        public ICollection<Models.Product> GetProducts();
    }
}
