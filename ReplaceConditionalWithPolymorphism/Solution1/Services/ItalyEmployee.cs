﻿using Solution1.Interfaces;
using System;
using System.Text;

namespace Solution1.Services
{
    public class ItalyEmployee : ICalculation
    {
        private double GrossAumont { get; set; }
         private double Revenue { get; set; }
        private double Pension { get; set; }
        private double NetAumont { get; set; }

        public void CalculatePayment(double hourValue, double monthlyHoursWorked)
        {
            GrossAumont = hourValue * monthlyHoursWorked;

            CalculateDeductions();
            PrintDetailsOnScreen();
        }

        private void CalculateDeductions()
        {
            CalculateRevenue();
            CalculatePension();
            CalculateNetAumont();
        }

        private void CalculatePension()
        {
            Pension = GrossAumont * 0.06;
        }

        private void CalculateRevenue()
        {
            var cutValue = 650;

            if (GrossAumont <= cutValue)
            {
                Revenue = GrossAumont * 0.06;
                return;
            }

            var firstValue = cutValue * 0.06;
            var restValue = (GrossAumont - cutValue) * 0.35;

            Revenue = firstValue + restValue;
        }

        private void CalculateNetAumont()
        {
            NetAumont = GrossAumont - Revenue - Pension;
        }

        public void PrintDetailsOnScreen()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Employee for ITALY");

            sb.Append("Gross salary: EUR ");
            sb.AppendLine(GrossAumont.ToString());

            sb.AppendLine();
            sb.AppendLine("CalculateDeductions details");
            sb.AppendLine("---------------------------------------");

            sb.Append("Revenue: EUR ");
            sb.AppendLine(Revenue.ToString());

            sb.Append("Pension: EUR ");
            sb.AppendLine(Pension.ToString());
            sb.AppendLine("---------------------------------------");

            sb.Append("Net salary: EUR ");
            sb.AppendLine(NetAumont.ToString());

            Console.WriteLine(sb.ToString());
        }
    }
}
