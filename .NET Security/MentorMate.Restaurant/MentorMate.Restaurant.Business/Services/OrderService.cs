using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.Data.Entities;
using MentorMate.Restaurant.Data.Repositories.Interfaces;
using MentorMate.Restaurant.Domain.Consts;
using MentorMate.Restaurant.Domain.Models.General;
using MentorMate.Restaurant.Domain.Models.Orders;

namespace MentorMate.Restaurant.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response> CompleteAsync(string waiterId, string orderId, bool isAdmin = false)
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

        public async Task<Response> CreateAsync(string waiterId, CreateOrderModel model)
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

        public async Task<Response> DeleteAsync(string id)
        {
            var response = new Response();

            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                response = new Response(false, Messages.OrderNotFound);

                return response;
            }

            await _orderRepository.DeleteAsync(order);

            response = new Response(true, Messages.OrderDeleted);

            return response;
        }

        public async Task<ICollection<Order>> GetAllAsync(bool onlyActive = false) =>
            await _orderRepository.GetAllAsync(onlyActive);

        public async Task<Order> GetByIdAsync(string id)
        {
            var result = await _orderRepository.GetByIdAsync(id);

            return result;
        }
    }
}
