namespace DesignPatterns.Observer.Business.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsSubscribed { get; set; }

        public void Notify(string change)
        {
            Console.WriteLine($"Customer {Id} named {Name} has been notified about {change}");
        }
    }
}
