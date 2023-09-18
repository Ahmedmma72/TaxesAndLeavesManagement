using FactoryPattern.Factories.PartFactory;

namespace FactoryPattern.Factories.Car
{
    // Step 2: Create concrete classes for each type of car.

    class Sedan : Car
    {
        public Sedan(CarPartFactory factory) : base(factory)
        {
        }

        public override void AssembleEngine()
        {
            Console.WriteLine($"Assembling {engine.GetDescription()} in Sedan.");
        }

        public override void AssembleBody()
        {
            Console.WriteLine($"Assembling {body.GetDescription()} in Sedan.");
        }

        public override void AssembleInterior()
        {
            Console.WriteLine($"Assembling {interior.GetDescription()} in Sedan.");
        }
    }
}