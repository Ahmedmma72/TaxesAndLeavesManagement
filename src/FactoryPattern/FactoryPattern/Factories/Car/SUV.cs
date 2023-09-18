using FactoryPattern.Factories.PartFactory;

namespace FactoryPattern.Factories.Car
{
    class SUV : Car
    {
        public SUV(CarPartFactory factory) : base(factory)
        {
        }

        public override void AssembleEngine()
        {
            Console.WriteLine($"Assembling {engine.GetDescription()} in SUV.");
        }

        public override void AssembleBody()
        {
            Console.WriteLine($"Assembling {body.GetDescription()} in SUV.");
        }

        public override void AssembleInterior()
        {
            Console.WriteLine($"Assembling {interior.GetDescription()} in SUV.");
        }
    }
}