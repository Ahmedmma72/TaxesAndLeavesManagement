using FactoryPattern.Factories.Part.Body;
using FactoryPattern.Factories.Part.Engine;
using FactoryPattern.Factories.Part.Interior;

namespace FactoryPattern.Factories.PartFactory
{
    // Step 3: Create concrete classes for each type of car part.

    class SedanPartFactory : CarPartFactory
    {
        public override Engine CreateEngine()
        {
            return new SedanEngine();
        }

        public override Body CreateBody()
        {
            return new SedanBody();
        }

        public override Interior CreateInterior()
        {
            return new SedanInterior();
        }
    }
}