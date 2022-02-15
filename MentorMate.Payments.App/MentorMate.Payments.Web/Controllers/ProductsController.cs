using MentorMate.Payment.Business.Models;
using MentorMate.Payment.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Payments.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            IProductService productService = new ProductService();
            var products = productService.GetProducts();
            return products.ToArray();
        }
    }
}
