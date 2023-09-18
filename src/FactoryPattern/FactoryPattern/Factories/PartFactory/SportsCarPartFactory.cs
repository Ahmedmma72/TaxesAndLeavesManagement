using FactoryPattern.Factories.Part.Body;
using FactoryPattern.Factories.Part.Engine;
using FactoryPattern.Factories.Part.Interior;

namespace FactoryPattern.Factories.PartFactory
{
    class SportsCarPartFactory : CarPartFactory
    {
        public override Engine CreateEngine()
        {
            return new SportsCarEngine();
        }

        public override Body CreateBody()
        {
            return new SportsCarBody();
        }

        public override Interior CreateInterior()
        {
            return new SportsCarInterior();
        }
    }
}