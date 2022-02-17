namespace Collections.Business.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
