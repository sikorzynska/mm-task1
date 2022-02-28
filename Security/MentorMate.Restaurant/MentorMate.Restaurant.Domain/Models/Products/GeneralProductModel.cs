namespace MentorMate.Restaurant.Domain.Models.Products
{
    public class GeneralProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

    }
}
