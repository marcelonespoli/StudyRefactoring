using Example1_Refactoring.Dto;
using Example1_Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example1_Refactoring.Reports
{
    public class StatementData
    {
        public string Customer { get; set; }
        public List<PerformanceData> Performances { get; set; }
        public decimal TotalAumont { get; set; }
        public decimal TotalVolumeCredits { get; set; }


        public StatementData Create(Invoice invoice, List<Play> plays)
        {
            var result = new StatementData
            {
                Customer = invoice.Customer,
                Performances = EnrichPerformance(invoice.Performances, plays)
            };
            result.TotalAumont = CalculateTotalAumont(result);
            result.TotalVolumeCredits = CalculateTotalVolumeCredits(result);
            return result;
        }

        private List<PerformanceData> EnrichPerformance(List<Performance> performances, List<Play> plays)
        {
            var result = new List<PerformanceData>();
            performances.ForEach(aPerformance =>
            {
                var calculator = CreatePerformanceCalculatorData(aPerformance, PlayFor(aPerformance, plays));
                var perf = new PerformanceData
                {
                    Performance = calculator.Performance,
                    Play = calculator.Play,
                    Aumont = calculator.Aumont,
                    VolumeCredits = calculator.VolumeCredits
                };
                result.Add(perf);
            });
            return result;
        }

        private PerformanceCalculator CreatePerformanceCalculatorData(Performance aPerformance, PlayDetails aPlay)
        {
            switch (aPlay.Type)
            {
                case "tragedy": return new TragedyCalculator(aPerformance, aPlay);
                case "comedy": return new ComedyCalculator(aPerformance, aPlay);
                default:
                    throw new Exception($"unknown type: { aPlay.Type }");
            }
        }

        private PlayDetails PlayFor(Performance aPerformance, List<Play> plays)
        {
            return plays.FirstOrDefault(x => x.Id == aPerformance.PlayId).Details;
        }

        private decimal CalculateTotalVolumeCredits(StatementData data)
        {
            return data.Performances.Sum(x => x.VolumeCredits);
        }

        private decimal CalculateTotalAumont(StatementData data)
        {
            return data.Performances.Sum(x => x.Aumont);
        }
                
    }
}
