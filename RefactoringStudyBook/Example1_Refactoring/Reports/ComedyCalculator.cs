using Example1_Refactoring.Models;

namespace Example1_Refactoring.Reports
{
    public class ComedyCalculator : PerformanceCalculator
    {
        public ComedyCalculator(Performance aPerformance, PlayDetails aPlay) 
            : base(aPerformance, aPlay)
        {
        }

            
        public override int Aumont
        {
            get
            {
                var result = 30000;
                if (Performance.Audience > 20)
                {
                    result += 10000 + 500 * (Performance.Audience - 20);
                }
                result += 300 * Performance.Audience;
                return result;
            }
        }

        public override decimal VolumeCredits
        {
            get
            {
                return base.VolumeCredits + (Performance.Audience / 5);
            }
        }
    }
}