using System;

namespace Probability.Core.Models
{
    public class CalculateProbabilityRequest
    {        
        public decimal ProbabilityOfA { get; set; }
        public decimal ProbabilityOfB { get; set; }
        public string CalculationType { get; set; }
    }
}
