using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Models.Sorting;
using MentorMate.Restaurant.Domain.Models.Sorting.Enums;
using Microsoft.EntityFrameworkCore;

namespace MentorMate.Restaurant.Data.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
        }

        //Get all
        public async Task<ICollection<Product>> GetAllAsync(ProductSortingModel sort)
        {
            var result = new List<Product>();

            if (sort == null)
            {
                result = await _dbContext.Products.ToListAsync();

                return result;
            }

            IQueryable<Product> products = _dbContext.Products;

            if (sort.Name != null)
            {
                products = products.Where(x => x.Name.ToLower().Contains(sort.Name.ToLower()));
            }

            if (sort.CategoryId != null)
            {
                products = products.Where(x => x.CategoryId == sort.CategoryId);
            }

            if (sort.OrderType != null && sort.OrderBy != null)
            {
                if (sort.OrderType == OrderType.Ascending)
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

        //Get by id
        public async Task<Product> GetByIdAsync(string id) =>
            await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        //Add
        public async Task CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);

            await _dbContext.SaveChangesAsync();
        }

        //Update
        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();
        }

        //Delete
        public async Task DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();
        }
    }
}
