using System.Text;

namespace MentorMate.Payment.Business.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Price: {Price}");

            return sb.ToString();
        }
    }
}
