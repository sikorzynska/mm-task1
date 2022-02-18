using MentorMate.Payment.Business.Models;
using Newtonsoft.Json;

namespace MentorMate.Payment.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly string jsonPath = string.Empty;
        public ProductService(string jsonPath) =>
            this.jsonPath = jsonPath;
        public ICollection<Product> GetProducts()
        {
            string productsJson = File.ReadAllText(jsonPath);
            var products = JsonConvert.DeserializeObject<Product[]>(productsJson);

            return products;
        }
    }
}
