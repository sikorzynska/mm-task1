using DesignPatterns.Observer.Business.Models;

namespace DesignPatterns.Observer.Business.Services
{
    public class BankService : IBankService
    {
        public ICollection<Customer> Customers = new List<Customer>();

        //Add customer method for testing purposes
        public void AddCustomer(Customer customer)
        {
            if(customer != null)
            {
                Customers.Add(customer);
            }
        }

        //Notify all subscribed customers of a change
        public void Update(string? update)
        {
            string updateMessage = update != null 
                ? update 
                : "some random change";

            foreach (var customer in Customers)
            {
                if (customer.IsSubscribed)
                {
                    customer.Notify(updateMessage);
                }
            }
        }
    }
}
