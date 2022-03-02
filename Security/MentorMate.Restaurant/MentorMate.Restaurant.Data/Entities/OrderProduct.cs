using System.ComponentModel.DataAnnotations.Schema;

namespace MentorMate.Restaurant.Data.Entities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        //Quantity for a particular product for easy access
        public int ProductCount { get; set; }
        //Price at the time of the order, in case it changes in the future, this will remain the same
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

    }
}
