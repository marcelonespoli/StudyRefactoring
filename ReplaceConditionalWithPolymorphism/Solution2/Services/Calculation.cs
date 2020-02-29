using Solution2.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Solution2.Services
{
    public abstract class Calculation : ICalculation
    {
        protected double GrossAumont { get; set; }

        public abstract void CalculatePayment(double hourValue, double monthlyHoursWorked);

        public abstract void PrintDetailsOnScreen();

        public class Factory
        {
            private static ICalculation Service { get; set; }

            public static void CalculePaymentFor(string location, double hourValue, double monthlyHoursWorked)
            {
                GetInstance(location);
                Service.CalculatePayment(hourValue, monthlyHoursWorked);
            }

            private static void GetInstance(string location)
            {
                //var assembly = Assembly.GetExecutingAssembly();
                //var type = assembly.GetTypes().First(t => t.Name == $"{location}Employee");

                var type = Type.GetType($"Solution2.Services.{location}Employee");

                Service = Activator.CreateInstance(type) as ICalculation;
            }
        }
    }
}
