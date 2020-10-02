using Example1_Refactoring.Models;
using System;

namespace Example1_Refactoring.Reports
{
    public abstract class PerformanceCalculator
    {
        public Performance Performance { get; set; }
        public PlayDetails Play { get; set; }

        public PerformanceCalculator(Performance aPerformance, PlayDetails aPlay)
        {
            Performance = aPerformance;
            Play = aPlay;
        }

        public virtual int Aumont
        {
            get {
                throw new Exception("Subclass reposability");
            }
        }

        public virtual decimal VolumeCredits
        {
            get {                
                return Math.Max(Performance.Audience - 30, 0);                
            }
        }
    }
}
