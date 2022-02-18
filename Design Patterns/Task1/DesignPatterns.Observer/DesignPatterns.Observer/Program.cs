using DesignPatterns.Observer.Business.Models;
using DesignPatterns.Observer.Business.Services;

namespace DesignPatterns.Observer
{
    public class Program
    {
        public static void Main()
        {
            IBankService _service = new BankService();
            _service.AddCustomer(new Customer() { Id = 1, Name = "John", IsSubscribed = false });
            _service.AddCustomer(new Customer() { Id = 2, Name = "Kyle", IsSubscribed = true });
            _service.AddCustomer(new Customer() { Id = 3, Name = "Bert", IsSubscribed = true });
            _service.AddCustomer(new Customer() { Id = 4, Name = "Tom", IsSubscribed = true });
            _service.AddCustomer(new Customer() { Id = 5, Name = "Christina", IsSubscribed = true });
            _service.AddCustomer(new Customer() { Id = 6, Name = "Veronica", IsSubscribed = true });
            _service.AddCustomer(new Customer() { Id = 7, Name = "Agent Romanoff", IsSubscribed = false });

            _service.Update("Tax increased by 60%.");
        }
    }
}
