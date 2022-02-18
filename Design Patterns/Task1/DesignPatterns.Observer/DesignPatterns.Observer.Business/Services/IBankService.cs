using DesignPatterns.Observer.Business.Models;

namespace DesignPatterns.Observer.Business.Services
{
    public interface IBankService
    {
        void AddCustomer(Customer customer);
        void Update(string update);
    }
}
