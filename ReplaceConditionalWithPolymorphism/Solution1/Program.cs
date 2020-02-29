using System;
using System.Collections.Generic;
using Solution1.Services;

namespace Solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            var locations = new List<string> { "Portugal", "Spain", "Italy" };

            foreach (var location in locations)
            {
                var paymentService = CalculationFactory.GetInstanceFor(location);
                paymentService.CalculatePayment(10, 40);

                Console.WriteLine();
                Console.WriteLine("*************************************************");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
