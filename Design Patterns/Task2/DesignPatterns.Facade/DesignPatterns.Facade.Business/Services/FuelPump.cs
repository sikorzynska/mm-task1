namespace DesignPatterns.Facade.Business.Services
{
    public class FuelPump
    {
        public void Start() =>
            Console.WriteLine("Fuel pump started...");

        public void Stop() =>
            Console.WriteLine("Fuel pump stopped...");
    }
}
