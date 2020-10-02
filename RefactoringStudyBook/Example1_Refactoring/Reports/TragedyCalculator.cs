using Example1_Refactoring.Models;

namespace Example1_Refactoring.Reports
{
    public class TragedyCalculator : PerformanceCalculator
    {
        public TragedyCalculator(Performance aPerformance, PlayDetails aPlay) 
            : base(aPerformance, aPlay)
        {            
        }

        public override int Aumont
        {
            get
            {
                var result = 40000;
                if (Performance.Audience > 30)
                {
                    result += 1000 * (Performance.Audience - 30);
                }
                return result;
            }
        }
    }
}
