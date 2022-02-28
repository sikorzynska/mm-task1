using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Products;

namespace MentorMate.Restaurant.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<GeneralProductModel>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var result = products.Select(x => new GeneralProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                CategoryId = x.CategoryId,
            }).ToList();

            return result;
        }

        public async Task<GeneralProductModel> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
            {
                return null;
            }

            var result = new GeneralProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            return result;
        }

        public async Task<ProductResponse> AddAsync(CreateProductModel model)
        {
            var result = new ProductResponse();

            if(!CategoryIsValid(model.CategoryId).Result)
            {
                result = new ProductResponse(false, Messages.ProductCategoryInvalid);

                return result;
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
            };

            await _productRepository.AddAsync(product);

            result = new ProductResponse(
                true,
                Messages.ProductCreated,
                new GeneralProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                });

            return result;
        }

        public async Task<ProductResponse> UpdateAsync(UpdateProductModel model)
        {
            var result = new ProductResponse();

            var existingProduct = await _productRepository.GetByIdAsync(model.Id);

            if(existingProduct == null)
            {
                result = new ProductResponse(false, Messages.ProductNotFound);

                return result;
            }

            if(model.CategoryId != null && !CategoryIsValid(model.CategoryId ?? 0).Result)
            {
                result = new ProductResponse(false, Messages.ProductCategoryInvalid);

                return result;
            }

            existingProduct.Name = model.Name ?? existingProduct.Name;
            existingProduct.CategoryId = model.CategoryId ?? existingProduct.CategoryId;
            existingProduct.Price = model.Price ?? existingProduct.Price;

            await _productRepository.UpdateAsync(existingProduct);

            result = new ProductResponse(
                true,
                Messages.ProductUpdated,
                new GeneralProductModel
                {
                    Id = existingProduct.Id,
                    Name = existingProduct.Name,
                    Price = existingProduct.Price,
                    CategoryId = existingProduct.CategoryId
                });

            return result;
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var result = new ProductResponse();

            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
            {
                result = new ProductResponse(false, Messages.ProductNotFound);

                return result;
            }

            await _productRepository.DeleteAsync(product);

            result = new ProductResponse(
                true,
                Messages.ProductDeleted,
                new GeneralProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                });

            return result;
        }

        private async Task<bool> CategoryIsValid(int categoryId) =>
           await _categoryRepository.GetByIdAsync(categoryId) != null;
    }
}
