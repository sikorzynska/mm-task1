namespace DesignPatterns.Facade.Business.Services
{
    public class CoolingPump
    {
        public void Start() =>
            Console.WriteLine("Cooling pump started...");

        public void Stop() =>
            Console.WriteLine("Cooling pump stopped...");
    }
}
