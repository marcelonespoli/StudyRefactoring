using Solution1.Interfaces;
using System;
using System.Text;

namespace Solution1.Services
{
    public class SpainEmployee : ICalculation
    {
        private double GrossAumont { get; set; }
        private double HealthInsurance { get; set; }
        private double Revenue { get; set; }
        private double NetAumont { get; set; }

        public void CalculatePayment(double hourValue, double monthlyHoursWorked)
        {
            GrossAumont = hourValue * monthlyHoursWorked;

            CalculateDeductions();
            PrintDetailsOnScreen();
        }

        private void CalculateDeductions()
        {
            CalculateHealthInsurance();
            CalculateRevenue();
            CalculateNetAumont();
        }

        private void CalculateHealthInsurance()
        {
            HealthInsurance = GrossAumont * 0.075;
        }

        private void CalculateRevenue()
        {
            var cutValue = 650;

            if (GrossAumont <= cutValue)
            {
                Revenue = GrossAumont * 0.03;
                return;
            }

            var firstValue = cutValue * 0.03;
            var restValue = (GrossAumont - cutValue) * 0.04;

            Revenue = firstValue + restValue;
        }

        private void CalculateNetAumont()
        {
            NetAumont = GrossAumont - HealthInsurance - Revenue;
        }

        public void PrintDetailsOnScreen()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Employee for SPAIN");

            sb.Append("Gross salary: EUR ");
            sb.AppendLine(GrossAumont.ToString());

            sb.AppendLine();
            sb.AppendLine("CalculateDeductions details");
            sb.AppendLine("---------------------------------------");

            sb.Append("Revenue: EUR ");
            sb.AppendLine(Revenue.ToString());

            sb.Append("Health Insurance: EUR ");
            sb.AppendLine(HealthInsurance.ToString());
            sb.AppendLine("---------------------------------------");

            sb.Append("Net salary: EUR ");
            sb.AppendLine(NetAumont.ToString());

            Console.WriteLine(sb.ToString());
        }
    }
}
