using Collections.Business.Models;

namespace Collections.Business.Services
{
    public interface IProductService
    {
        public ICollection<Product> GetEnabledProducts();
        public ICollection<Product> GetProductsByName(string name);
        public ICollection<Product> GetProductsByIngredient(string ingredient);

    }

}
