using Collections.Business.Models;
using Newtonsoft.Json;

namespace Collections.Business.Services
{
    public class ProductService : IProductService
    {
        private IReadOnlyCollection<Product> products;
        public ProductService(string jsonPath)
        {
            string productsJson = File.ReadAllText(jsonPath);
            this.products = JsonConvert.DeserializeObject<Product[]>(productsJson);
        }
        public ICollection<Product> GetEnabledProducts() =>
            this.products.Where(x => x.IsEnabled).ToList();

        public ICollection<Product> GetProductsByIngredient(string ingredient) =>
            this.products
                .Where(x => x.Ingredients
                .Any(v => v.ToLower().Contains(ingredient.ToLower())))
                .ToList();

        public ICollection<Product> GetProductsByName(string name) =>
            this.products
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToList();
    }
}
