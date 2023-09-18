using FactoryPattern.Factories.Part.Body;
using FactoryPattern.Factories.Part.Engine;
using FactoryPattern.Factories.Part.Interior;

namespace FactoryPattern.Factories.PartFactory
{
    abstract class CarPartFactory
    {
        public abstract Engine CreateEngine();
        public abstract Body CreateBody();
        public abstract Interior CreateInterior();
    }
}