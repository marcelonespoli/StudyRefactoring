using Solution1.Interfaces;
using System.Collections.Generic;

namespace Solution1.Services
{
    public class CalculationFactory
    {
        private static Dictionary<string, ICalculation> Locations = new Dictionary<string, ICalculation>
        {
            { "Portugal", new PortugalEmployee() },
            { "Spain", new SpainEmployee() },
            { "Italy", new ItalyEmployee() },
        };

        public static ICalculation GetInstanceFor(string location)
        {
            return Locations[location];
        }
    }
}
