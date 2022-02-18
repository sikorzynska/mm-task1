using MentorMate.Payment.Business.Models;
using MentorMate.Payment.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Payments.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        const string jsonPath = "../MentorMate.Payment.Business/Datasets/products.json";

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            IProductService _service = new ProductService(jsonPath);
            var products = _service.GetProducts();
            return products.ToArray();
        }
    }
}
