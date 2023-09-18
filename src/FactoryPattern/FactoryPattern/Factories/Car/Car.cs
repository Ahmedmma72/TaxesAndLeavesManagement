using FactoryPattern.Factories.PartFactory;
using FactoryPattern.Factories.Part.Body;
using FactoryPattern.Factories.Part.Engine;
using FactoryPattern.Factories.Part.Interior;

namespace FactoryPattern.Factories.Car
{
    abstract class Car
    {
        protected Engine engine;
        protected Body body;
        protected Interior interior;

        public Car(CarPartFactory factory)
        {
            engine = factory.CreateEngine();
            body = factory.CreateBody();
            interior = factory.CreateInterior();
        }

        public abstract void AssembleEngine();
        public abstract void AssembleBody();
        public abstract void AssembleInterior();
    }
}