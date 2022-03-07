using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Sorting;

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

        public async Task<ICollection<Product>> GetAllAsync(ProductSortingModel sort) =>
            await _productRepository.GetAllAsync(sort);

        public async Task<Product> GetByIdAsync(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return product;
        }

        public async Task<Response> CreateAsync(CreateProductModel model)
        {
            var response = new Response();

            if(!CategoryValidAsync(model.CategoryId).Result)
            {
                response = new Response(false, Messages.ProductCategoryInvalid);

                return response;
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
            };

            await _productRepository.AddAsync(product);

            response = new Response(true, Messages.ProductCreated, product.Id);

            return response;
        }

        public async Task<Response> UpdateAsync(string productId, UpdateProductModel model)
        {
            var response = new Response();

            var product = await _productRepository.GetByIdAsync(productId);

            if(product == null)
            {
                response = new Response(false, Messages.ProductNotFound);

                return response;
            }

            if(model.CategoryId != null && !CategoryValidAsync(model.CategoryId ?? string.Empty).Result)
            {
                response = new Response(false, Messages.ProductCategoryInvalid);

                return response;
            }

            product.Name = model.Name ?? product.Name;
            product.CategoryId = model.CategoryId ?? product.CategoryId;
            product.Price = model.Price ?? product.Price;

            await _productRepository.UpdateAsync(product);

            response = new Response(true, Messages.ProductUpdated);

            return response;
        }

        #region private functions
        public async Task<Response> DeleteAsync(string id)
        {
            var response = new Response();

            var product = await _productRepository.GetByIdAsync(id);

            if(product == null)
            {
                response = new Response(false, Messages.ProductNotFound);

                return response;
            }

            await _productRepository.DeleteAsync(product);

            response = new Response(true, Messages.ProductDeleted);

            return response;
        }

        private async Task<bool> CategoryValidAsync(string categoryId) =>
           await _categoryRepository.GetByIdAsync(categoryId) != null;
        #endregion
    }
}
