using FactoryPattern.Factories.PartFactory;

namespace FactoryPattern.Factories.Car
{
    class SportsCar : Car
    {
        public SportsCar(CarPartFactory factory) : base(factory)
        {
        }

        public override void AssembleEngine()
        {
            Console.WriteLine($"Assembling {engine.GetDescription()} in Sports Car.");
        }

        public override void AssembleBody()
        {
            Console.WriteLine($"Assembling {body.GetDescription()} in Sports Car.");
        }

        public override void AssembleInterior()
        {
            Console.WriteLine($"Assembling {interior.GetDescription()} in Sports Car.");
        }
    }
}