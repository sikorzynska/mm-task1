using DesignPatterns.Facade.Business.Services;

namespace DesignPatterns.Facade
{
    public class Program
    {
        //A little program inside main for easy testing of the engine...
        public static void Main()
        {
            var _engine = new Engine();

            Console.WriteLine("Commands:");
            Console.WriteLine("Type 'start' to start the engine");
            Console.WriteLine("Type 'stop' to stop the engine");
            Console.WriteLine("Type 'exit' to exit the vehicle.");

            string command;
            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                switch (command)
                {
                    case "start":
                        {
                            _engine.Start();
                            break;
                        }
                    case "stop":
                        {
                            _engine.Stop();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid command, try again.");
                            break;
                        }
                }
            }
        }
    }
}
