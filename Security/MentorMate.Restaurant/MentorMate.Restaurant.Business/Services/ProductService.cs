using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Sorting;
using MentorMate.Restaurant.Domain.Models.Sorting.Enums;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Product>> GetAllAsync(ProductSortingModel sort)
        {
            var result = new List<Product>();

            if(sort == null)
            {
                result = await _productRepository.GetAll().ToListAsync();

                return result;
            }

            IQueryable<Product> products = _productRepository.GetAll();

            if(sort.Name != null)
            {
                products = products.Where(x => x.Name.ToLower().Contains(sort.Name.ToLower()));
            }

            if(sort.CategoryId != null)
            {
                products = products.Where(x => x.CategoryId == sort.CategoryId);
            }

            if(sort.OrderType != null && sort.OrderBy != null)
            {
                if(sort.OrderType == OrderType.Ascending)
                {
                    if (sort.OrderBy == OrderByType.Name)
                    {
                        products = products.OrderBy(x => x.Name);
                    }
                    else
                    {
                        products = products.OrderBy(x => x.CategoryId);
                    }
                }
                else
                {
                    if (sort.OrderBy == OrderByType.Name)
                    {
                        products = products.OrderByDescending(x => x.Name);
                    }
                    else
                    {
                        products = products.OrderByDescending(x => x.CategoryId);
                    }
                }
            }

            result = await products.ToListAsync();

            return result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return product;
        }

        public async Task<Response> CreateAsync(CreateProductModel model)
        {
            var response = new Response();

            if(!CategoryIsValid(model.CategoryId).Result)
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

            response = new Response(true, Messages.ProductCreated);

            return response;
        }

        public async Task<Response> UpdateAsync(int productId, UpdateProductModel model)
        {
            var response = new Response();

            var product = await _productRepository.GetByIdAsync(productId);

            if(product == null)
            {
                response = new Response(false, Messages.ProductNotFound);

                return response;
            }

            if(model.CategoryId != null && !CategoryIsValid(model.CategoryId ?? 0).Result)
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

        public async Task<Response> DeleteAsync(int id)
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

        private async Task<bool> CategoryIsValid(int categoryId) =>
           await _categoryRepository.GetByIdAsync(categoryId) != null;
    }
}
