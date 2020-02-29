using Solution2.Services;
using System;
using System.Collections.Generic;

namespace Solution2
{
    class Program
    {
        static void Main(string[] args)
        {
            var locations = new List<string> { "Portugal", "Spain", "Italy" };

            foreach (var location in locations)
            {
                Calculation.Factory.CalculePaymentFor(location, 10, 40);

                Console.WriteLine();
                Console.WriteLine("*************************************************");
                Console.WriteLine();
            }            

            Console.ReadLine();
        }
    }
}
