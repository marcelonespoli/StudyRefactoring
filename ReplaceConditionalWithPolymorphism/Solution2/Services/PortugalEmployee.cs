using System;
using System.Text;

namespace Solution2.Services
{
    public class PortugalEmployee : Calculation
    {
        private double HealthInsurance { get; set; }
        private double Revenue { get; set; }
        private double Pension { get; set; }
        private double NetAumont { get; set; }

        public override void CalculatePayment(double hourValue, double monthlyHoursWorked)
        {
            GrossAumont = hourValue * monthlyHoursWorked;

            CalculateDeductions();
            PrintDetailsOnScreen();
        }

        private void CalculateDeductions()
        {
            CalculateHealthInsurance();
            CalculateRevenue();
            CalculatePension();
            CalculateNetAumont();
        }

        private void CalculateHealthInsurance()
        {
            HealthInsurance = GrossAumont * 0.05;
        }

        private void CalculateRevenue()
        {
            var cutValue = 500;

            if (GrossAumont <= cutValue)
            {
                Revenue = GrossAumont * 0.05;
                return;
            }

            var firstValue = cutValue * 0.05;
            var restValue = (GrossAumont - cutValue) * 0.02;

            Revenue = firstValue + restValue;
        }

        private void CalculatePension()
        {
            Pension = GrossAumont * 0.06;
        }

        private void CalculateNetAumont()
        {
            NetAumont = GrossAumont - HealthInsurance - Revenue - Pension;
        }

        public override void PrintDetailsOnScreen()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Employee for PORTUGAL");

            sb.Append("Gross salary: EUR ");
            sb.AppendLine(GrossAumont.ToString());

            sb.AppendLine();
            sb.AppendLine("CalculateDeductions details");
            sb.AppendLine("---------------------------------------");

            sb.Append("Revenue: EUR ");
            sb.AppendLine(Revenue.ToString());

            sb.Append("Pension: EUR ");
            sb.AppendLine(Pension.ToString());

            sb.Append("Health Insurance: EUR ");
            sb.AppendLine(HealthInsurance.ToString());
            sb.AppendLine("---------------------------------------");

            sb.Append("Net salary: EUR ");
            sb.AppendLine(NetAumont.ToString());

            Console.WriteLine(sb.ToString());
        }
    }
}
