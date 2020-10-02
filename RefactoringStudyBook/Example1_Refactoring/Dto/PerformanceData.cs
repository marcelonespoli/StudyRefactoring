using Example1_Refactoring.Models;

namespace Example1_Refactoring.Dto
{
    public class PerformanceData
    {
        public Performance Performance { get; set; }
        public PlayDetails Play { get; set; }
        public int Aumont { get; set; }
        public decimal VolumeCredits { get; set; }
    }
}
