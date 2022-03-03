using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.Domain.Models.Orders;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.WebApi.Services
{
    public static class Mapper
    {
        #region product
        public static IEnumerable<GeneralProductModel> MapProductCollection(IEnumerable<Product> products) =>
            products.Select(x => new GeneralProductModel
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Price = x.Price,
            }).ToList();

        public static GeneralProductModel MapProduct(Product product) =>
            new GeneralProductModel
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
            };
        #endregion

        #region user
        public static IEnumerable<GeneralUserModel> MapUserCollection(IEnumerable<User> users) =>
            users.Select(x => new GeneralUserModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PictureURL = x.PictureURL,
                Email = x.Email,
            }).ToList();

        public static GeneralUserModel MapUser(User user) =>
            new GeneralUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PictureURL = user.PictureURL,
                Email = user.Email,
            };
        #endregion

        #region category
        public static IEnumerable<GeneralCategoryModel> MapCategoryCollection(IEnumerable<Category> categories) =>
            categories.Select(x => new GeneralCategoryModel
            {
                Id = x.Id,
                Name = x.Name,
                Subcategories = x.Children.Select(v => new GeneralCategoryModel
                {
                    Id = v.Id,
                    Name= v.Name,
                }).ToList(),
            }).ToList();

        public static GeneralCategoryModel MapCategory(Category category) =>
            new GeneralCategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
                Subcategories = category.Children.Select(v => new GeneralCategoryModel
                {
                    Id = v.Id,
                    Name = v.Name
                }).ToList()
            };
        #endregion

        #region order
        public static IEnumerable<GeneralOrderModel> MapOrderCollection(IEnumerable<Order> orders) =>
            orders.Select(o => new GeneralOrderModel
            {
                Id = o.Id,
                TableId = o.TableId,
                Waiter = o.Waiter.FirstName + " " + o.Waiter.LastName,
                DateTime = o.DateTime.ToString("dddd, dd MMMM yyyy"),
                Status = o.Status.ToString(),
                Price = o.OrderProducts.Select(x => x.ProductPrice * x.ProductCount).Sum(),
                Products = o.OrderProducts.Select(x => new OrderProductModel
                {
                    Name = x.Product.Name,
                    Quantity = x.ProductCount,
                    Price = x.ProductPrice,
                    TotalPrice = x.ProductPrice * x.ProductCount,
                }).ToList(),
            }).ToList();

        public static GeneralOrderModel MapOrder(Order order) =>
            new GeneralOrderModel
            {
                Id = order.Id,
                TableId = order.TableId,
                Waiter = order.Waiter.FirstName + " " + order.Waiter.LastName,
                DateTime = order.DateTime.ToString("dddd, dd MMMM yyyy"),
                Status = order.Status.ToString(),
                Price = order.OrderProducts.Select(x => x.ProductPrice * x.ProductCount).Sum(),
                Products = order.OrderProducts.Select(x => new OrderProductModel
                {
                    Name = x.Product.Name,
                    Quantity = x.ProductCount,
                    Price = x.ProductPrice,
                    TotalPrice = x.ProductPrice * x.ProductCount,
                }).ToList(),
            };
        #endregion
    }
}
