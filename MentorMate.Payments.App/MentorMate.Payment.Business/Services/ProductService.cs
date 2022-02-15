using MentorMate.Payment.Business.Models;
using Newtonsoft.Json;

namespace MentorMate.Payment.Business.Services
{
    public class ProductService : IProductService
    {
        public ICollection<Product> GetProducts(bool fromApp = false)
        {
            string productsJson = 
                !fromApp 
                ? File.ReadAllText("../MentorMate.Payment.Business/Datasets/products.json")
                : File.ReadAllText("../../../../MentorMate.Payment.Business/Datasets/products.json");

            var products = JsonConvert.DeserializeObject<Product[]>(productsJson);

            return products;
        }
    }
}
