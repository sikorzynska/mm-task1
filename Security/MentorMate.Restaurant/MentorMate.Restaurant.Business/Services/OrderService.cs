using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Entities.Enums;
using MentorMate.Restaurant.Data.Misc;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.Orders;
using MentorMate.Restaurant.Domain.Models.Users;

namespace MentorMate.Restaurant.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, 
            IProductRepository productRepository,
            ITableRepository tableRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _tableRepository = tableRepository;
        }

        public async Task<OrderResponse> CompleteAsync(string waiterId, int orderId, bool isAdmin = false)
        {
            throw new ArgumentException();
            //var result = new OrderResponse();

            //var order = await _orderRepository.GetByIdAsync(orderId);

            //if(order == null)
            //{
            //    result = new OrderResponse(false, Messages.OrderNotFound);

            //    return result;
            //}

            //if(order.Status == OrderStatus.Complete)
            //{
            //    result = new OrderResponse(false, Messages.OrderAlreadyCompleted);

            //    return result;
            //}

            //if(order.WaiterId != waiterId && !isAdmin)
            //{
            //    result = new OrderResponse(false, Messages.OrderUnauthorized);

            //    return result;
            //}

            //order.Status = OrderStatus.Complete;

            //await _orderRepository.UpdateAsync(order);

            //var orderModel = new GeneralOrderModel
            //{
            //    Id = order.Id,
            //    TableId = order.TableId,
            //    Waiter = new GeneralUserModel
            //    {
            //        Id = order.WaiterId,
            //        FirstName = order.Waiter.FirstName,
            //        LastName = order.Waiter.LastName,
            //        Username = order.Waiter.UserName,
            //        Email = order.Waiter.Email,
            //    },
            //    DateTime = order.DateTime,
            //    Status = order.Status.ToString(),
            //    Price = order.TotalPrice,
            //    Products = order.Products.GroupBy(p => p.Name)
            //    .Select(r => new OrderProductModel
            //    {
            //        Name = r.Key,
            //        Quantity = r.Count(p => p.Name == r.Key),
            //        Price = r.FirstOrDefault(p => p.Name == r.Key).Price,
            //        TotalPrice = r.Sum(p => p.Price)

            //    }).ToList()
            //};

            //result = new OrderResponse(true, Messages.OrderCompleted, orderModel);

            //return result;

        }

        public async Task<OrderResponse> CreateAsync(string waiterId, CreateOrderModel model)
        {
            throw new ArgumentException(nameof(model));
            //var result = new OrderResponse();

            //var table = await _tableRepository.GetByIdAsync(model.TableId);

            //if(table == null)
            //{
            //    result = new OrderResponse(false, Messages.InvalidTableId);

            //    return result;
            //}

            //if(!model.ProductIds.Any())
            //{
            //    result = new OrderResponse(false, Messages.OrderProductsRequired);

            //    return result;
            //}

            //var products = new List<Product>();

            //foreach (var productId in model.ProductIds)
            //{
            //    var product = await _productRepository.GetByIdAsync(productId);

            //    if (product == null)
            //    {
            //        result = new OrderResponse(false, string.Format(Messages.OrderInvalidProductId, productId));

            //        return result;
            //    }

            //    products.Add(product);
            //}

            //var order = new Order
            //{
            //    TableId = model.TableId,
            //    WaiterId = waiterId,
            //    Products = products,
            //};

            //await _orderRepository.AddAsync(order);

            //var orderModel = new GeneralOrderModel
            //{
            //    Id = order.Id,
            //    TableId = order.TableId,
            //    Waiter = new GeneralUserModel
            //    {
            //        Id = order.WaiterId,
            //        FirstName = order.Waiter.FirstName,
            //        LastName = order.Waiter.LastName,
            //        Username = order.Waiter.UserName,
            //        Email = order.Waiter.Email,
            //    },
            //    DateTime = order.DateTime,
            //    Status = order.Status.ToString(),
            //    Price = order.TotalPrice,
            //    Products = order.Products.GroupBy(p => p.Name)
            //    .Select(r => new OrderProductModel
            //    {
            //        Name = r.Key,
            //        Quantity = r.Count(p => p.Name == r.Key),
            //        Price = r.FirstOrDefault(p => p.Name == r.Key).Price,
            //        TotalPrice = r.Sum(p => p.Price)

            //    }).ToList()
            //};

            //result = new OrderResponse(true, Messages.OrderCreated, orderModel);

            //return result;
        }

        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var result = new OrderResponse();

            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                result = new OrderResponse(false, Messages.OrderNotFound);

                return result;
            }

            await _orderRepository.DeleteAsync(order);

            result = new OrderResponse(true, Messages.OrderDeleted,
                new GeneralOrderModel
                {
                    Id = order.Id,
                    TableId = order.TableId,
                    Waiter = order.Waiter.FirstName + " " + order.Waiter.LastName,
                    DateTime = order.DateTime.ToString("dddd, dd MMMM yyyy"),
                    Status = order.Status.ToString(),
                    Price = OrderTotalPrice(order).Result,
                    Products = OrderProductModelList(order).Result,
                });

            return result;
        }

        public async Task<IEnumerable<GeneralOrderModel>> GetActiveAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            var result = orders.Where(x => x.Status == OrderStatus.Active)
                .Select(o => new GeneralOrderModel
            {
                Id = o.Id,
                TableId = o.TableId,
                Waiter = o.Waiter.FirstName + " " + o.Waiter.LastName,
                DateTime = o.DateTime.ToString("dddd, dd MMMM yyyy"),
                Status = o.Status.ToString(),
                Price = OrderTotalPrice(o).Result,
                Products = OrderProductModelList(o).Result,
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<GeneralOrderModel>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            var result = orders.Select(o => new GeneralOrderModel
            {
                Id = o.Id,
                TableId = o.TableId,
                Waiter = o.Waiter.FirstName + " " + o.Waiter.LastName,
                DateTime = o.DateTime.ToString("dddd, dd MMMM yyyy"),
                Status = o.Status.ToString(),
                Price = OrderTotalPrice(o).Result,
                Products = OrderProductModelList(o).Result,
            }).ToList();

            return result;
        }

        public async Task<GeneralOrderModel> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if(order == null)
            {
                return null;
            }

            var result = new GeneralOrderModel
            {
                Id = order.Id,
                TableId = order.TableId,
                Waiter = order.Waiter.FirstName + " " + order.Waiter.LastName,
                DateTime = order.DateTime.ToString("dddd, dd MMMM yyyy"),
                Status = order.Status.ToString(),
                Price = OrderTotalPrice(order).Result,
                Products = OrderProductModelList(order).Result,
            };

            return result;
        }

        #region inner functions
        //Inner function for getting the total price of an order
        private async Task<decimal> OrderTotalPrice(Order order)
        {
            //Get the order's OrderProducts
            var orderProducts = order.OrderProducts;

            //Initialize new decimal variable
            var orderPrice = 0m;

            //Foreach loop to calculate the price of each OrderProduct
            foreach (var op in orderProducts)
            {
                //Multiply the product's price by the product quantity to get the total
                var totalProductPrice = op.ProductPrice * op.ProductCount;

                //Add the product total to the order total
                orderPrice += totalProductPrice;
            }

            //Return order total
            return orderPrice;
        }

        //Inner function for getting a collection of OrderProductModel of a particular order
        private async Task<List<OrderProductModel>> OrderProductModelList(Order order)
        {
            //Initialize a new list of OrderProductModel
            var opmList = new List<OrderProductModel>();

            //Get the order's OrderProducts
            var orderProducts = order.OrderProducts;

            //Foreach loop to convert all OrderProducts to OrderProductModels and fill up the opmList
            foreach (var op in orderProducts)
            {
                //Get the particular product so we can access it's properties
                var product = await _productRepository.GetByIdAsync(op.ProductId);

                //Create a new OrderProductModel
                var opm = new OrderProductModel
                {
                    Name = product.Name,
                    Quantity = op.ProductCount,
                    Price = op.ProductPrice,
                    TotalPrice = product.Price * op.ProductCount,
                };

                //Add the OPM to the list
                opmList.Add(opm);
            }

            //Return the result
            return opmList;
        }
        #endregion
    }
}
