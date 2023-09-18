using FactoryPattern.Factories.Part.Body;
using FactoryPattern.Factories.Part.Engine;
using FactoryPattern.Factories.Part.Interior;

namespace FactoryPattern.Factories.PartFactory
{
    class SUVPartFactory : CarPartFactory
    {
        public override Engine CreateEngine()
        {
            return new SUVEngine();
        }

        public override Body CreateBody()
        {
            return new SUVBody();
        }

        public override Interior CreateInterior()
        {
            return new SUVInterior();
        }
    }
}