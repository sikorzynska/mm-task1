using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Models.Products;

namespace MentorMate.Restaurant.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<Product> GetByIdAsync(int id) =>
            await _productRepository.GetByIdAsync(id);

        public async Task AddAsync(ProductModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Price = model.Price,
            };

            await _productRepository.AddAsync(product);
        }

        public async Task<bool> UpdateAsync(int productId, ProductModel model)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productId);

            if(existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = model.Name;
            existingProduct.CategoryId = model.CategoryId;
            existingProduct.Price = model.Price;

            await _productRepository.UpdateAsync(existingProduct);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
            {
                return false;
            }

            await _productRepository.DeleteAsync(product);

            return true;
        }
    }
}
