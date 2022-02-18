namespace DesignPatterns.Facade.Business.Services
{
    public class AirflowSensor
    {
        public void Enable() =>
            Console.WriteLine("Airflow sensor enabled...");

        public void Disable() =>
            Console.WriteLine("Airflow sensor disabled...");
    }
}
