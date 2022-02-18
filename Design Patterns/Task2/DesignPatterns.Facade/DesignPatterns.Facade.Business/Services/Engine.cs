namespace DesignPatterns.Facade.Business.Services
{
    //The engine, AKA the facade...
    public class Engine
    {
        AirflowSensor _airflowSensor = null;
        FuelPump _fuelPump = null;
        EngineStarter _engineStarter = null;
        CoolingPump _coolingPump = null;
        bool isRunning;

        public Engine()
        {
            _airflowSensor = new AirflowSensor();
            _fuelPump = new FuelPump();
            _engineStarter = new EngineStarter();
            _coolingPump = new CoolingPump();
            isRunning = false;
        }
        public void Start()
        {
            if(isRunning)
            {
                Console.WriteLine("Engine is already running...");
            }
            else
            {
                _airflowSensor.Enable();
                _fuelPump.Start();
                _engineStarter.Enable();
                _coolingPump.Start();
                isRunning = true;
                Console.WriteLine("Engine has started.");
            }
        }

        public void Stop()
        {
            if(!isRunning)
            {
                Console.WriteLine("Engine is not running...");
            }
            else
            {
                _airflowSensor.Disable();
                _fuelPump.Stop();
                _coolingPump.Stop();
                isRunning = false;
                Console.WriteLine("Engine has stopped.");
            }
        }
    }
}
