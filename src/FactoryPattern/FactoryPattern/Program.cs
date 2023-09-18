using FactoryPattern.Factories.Car;
using FactoryPattern.Factories.PartFactory;

namespace FactoryPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select a car type:");
            Console.WriteLine("1 - Sedan");
            Console.WriteLine("2 - SUV");
            Console.WriteLine("3 - Sports Car");

            bool stat = int.TryParse(Console.ReadLine(),out int choice);

            while (!stat)
            {
                Console.WriteLine("Invalid choice please try again:");
                stat = int.TryParse(Console.ReadLine(), out choice);
            }

            Car car;
            CarPartFactory partFactory;

            switch (choice)
            {
                case 1:
                    partFactory = new SedanPartFactory();
                    car = new Sedan(partFactory);
                    break;
                case 2:
                    partFactory = new SUVPartFactory();
                    car = new SUV(partFactory);
                    break;
                case 3:
                    partFactory = new SportsCarPartFactory();
                    car = new SportsCar(partFactory);
                    break;
                default:
                    Console.WriteLine("Invalid choice please try again:");
                    return;
            }
            car.AssembleEngine();
            car.AssembleBody();
            car.AssembleInterior();

            Console.WriteLine("Car manufacturing complete.");
        }
    }
}