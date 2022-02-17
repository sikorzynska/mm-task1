using System.Globalization;
using System.Text;

namespace Collections.Business.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();

        public decimal TotalPrice { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Order ID: {this.Id}");
            sb.AppendLine($"DateTime: {this.DateTime.ToString("MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Products:");
            foreach (var product in this.Products)
            {
                sb.AppendLine($"x{product.Quantity} {product.Product.Name} - ${product.Quantity * product.Product.Price}");
            }
            sb.AppendLine($"Total Price: ${this.TotalPrice}");

            return sb.ToString();
        }
    }
}
