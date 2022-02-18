using MentorMate.Payment.Business.Models;
using MentorMate.Payment.Business.Services;
using MentorMate.Payment.Business.Providers;

const string jsonPath = "../../../../MentorMate.Payment.Business/Datasets/products.json";

IProductService _service = new ProductService(jsonPath);
var products = _service.GetProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ToString());
}

Console.WriteLine("Please type the ID of the product that you would like to purchase.");

var chosenProduct = new Product();

while (true)
{
    var productInput = Console.ReadLine();

    if (String.IsNullOrEmpty(productInput) || !int.TryParse(productInput, out int n) || !products.Any(x => x.Id == int.Parse(productInput)))
    {
        Console.WriteLine("Invalid product ID, please try again.");
    }
    else
    {
        chosenProduct = products.FirstOrDefault(x => x.Id == int.Parse(productInput));
        break;
    }
}

IPaymentProvider paymentProvider = null;

Console.WriteLine("Please choose a payment provider:");
Console.WriteLine("Type '1' for PayPal");
Console.WriteLine("Type '2' for Stripe");

while (true)
{
    var paymentInput = Console.ReadLine();

    if(String.IsNullOrEmpty(paymentInput) || !int.TryParse(paymentInput, out int n) || int.Parse(paymentInput) != 1 && int.Parse(paymentInput) != 2)
    {
        Console.WriteLine("Invalid payment provider, please try again.");
    }
    else
    {
        switch (int.Parse(paymentInput))
        {
            case 1:
                {
                    paymentProvider = new PayPalPaymentProvider();
                    break;
                }
            case 2:
            {
                paymentProvider = new StripePaymentProvider();
                break;
            }
            default:
                break;
        }
        break;
    }
}

var payment = new Payment
{
    Amount = chosenProduct.Price,
    Description = chosenProduct.Description
};

paymentProvider.ProcessPayment(payment);