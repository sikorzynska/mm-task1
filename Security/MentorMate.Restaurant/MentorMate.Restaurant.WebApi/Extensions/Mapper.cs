using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Entities.Enums;
using MentorMate.Restaurant.Domain.Models.Categories;
using MentorMate.Restaurant.Domain.Models.Orders;
using MentorMate.Restaurant.Domain.Models.Products;
using MentorMate.Restaurant.Domain.Models.Tables;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.WebApi.Extensions
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
            orders.Select(x => new GeneralOrderModel
            {
                Id = x.Id,
                TableId = x.TableId,
                Waiter = x.Waiter.FirstName + " " + x.Waiter.LastName,
                DateTime = x.DateTime.ToString("dddd, dd MMMM yyyy"),
                Status = x.Status.ToString(),
                Price = x.OrderProducts.Select(x => x.ProductPrice * x.ProductCount).Sum(),
                Products = x.OrderProducts.Select(x => new OrderProductModel
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

        #region table
         public static IEnumerable<GeneralTableModel> MapTableCollection(IEnumerable<Table> tables) =>
            tables.Select(x => new GeneralTableModel
            {
                Id = x.Id,
                Status = x.Status.ToString(),
                Capacity = x.Capacity,
                Waiter = x.Status == TableStatus.Active
                ? x.Waiter.FirstName + " " + x.Waiter.LastName
                : "N/A",
                Bill = x.Status == TableStatus.Active
                ? x.Orders.SelectMany(x => x.OrderProducts.Select(v => v.ProductPrice * v.ProductCount)).Sum().ToString()
                : "0 BGN",
            }).ToList();

        public static GeneralTableModel MapTable(Table table) =>
            new GeneralTableModel
            {
                Id = table.Id,
                Status = table.Status.ToString(),
                Capacity = table.Capacity,
                Waiter = table.Status == TableStatus.Active
                ? table.Waiter.FirstName + " " + table.Waiter.LastName
                : "N/A",
                Bill = table.Status == TableStatus.Active
                ? table.Orders.SelectMany(x => x.OrderProducts.Select(v => v.ProductPrice * v.ProductCount)).Sum().ToString()
                : "0 BGN",
            };
        #endregion
    }
}
