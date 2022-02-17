using System.Text;

namespace Collections.Business.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; } 

        public ICollection<string> Ingredients { get; set; } = new List<string>();

        public decimal Price { get; set; }

        public bool IsEnabled { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"ID: {this.Id}");
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Description: {this.Description}");
            sb.AppendLine($"Image URL: {this.Picture}");
            sb.Append($"Ingredients: ");
            foreach (var ingredient in this.Ingredients)
            {
                sb.Append(ingredient + ", ");
            }
            sb.AppendLine();
            sb.AppendLine($"Price: ${this.Price}");
            sb.AppendLine($"Is Enabled: {this.IsEnabled}");

            return sb.ToString();
        }
    }
}
